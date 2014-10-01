//-----------------------------------------------------------------------------
// Copyright 2008 (C) LogicKing.com, Inc.
//-----------------------------------------------------------------------------

#include "T3D/logickingMechanics/physics/physx/physShapePhysX.h"
//
#include "platform/platform.h"
#include "T3D/physics/physx3/px3Body.h"

#include "T3D/physics/physx3/px3.h"
#include "T3D/physics/physx3/px3Casts.h"
#include "T3D/physics/physx3/px3World.h"
#include "T3D/physics/physx3/px3Collision.h"

#include "console/console.h"
#include "console/consoleTypes.h"
//
/* test ? fail.. ?
PhysShapePhysX::PhysShapePhysX() :
   mActor( NULL ),
   mMaterial( NULL ),
   mWorld( NULL ),
   mBodyFlags( 0 ),
   mIsEnabled( true ),
   mIsStatic(false)
{
	// is empty..
}*/

PhysShapePhysX::PhysShapePhysX(Physics* phys, const PhysInfo &physDescr) : 
	PhysShape(physDescr)/*, // shape parameters & description
	mIsEnabled( true ), // are the physics on ?
	mBodyFlags( 0 ) // our flags (0 = deactivated shape/trigger shape)*/
{
	PhysicsPhysX* physics = static_cast<PhysicsPhysX*>(phys);
	m_world = physics->getWorld();
	m_scene = physics->getPhysScene();


	physx::PxShape* shapeDesc = NULL;
	if (m_physInfo.shapeType == PhysInfo::ST_BOX)
	{
		physx::PxVec3 halfSize = 0.5f * vectorToPx(m_physInfo.params);
		//physx::PxShape* boxShapeDesc;
		Px3CollisionDesc *boxShapeDesc = new Px3CollisionDesc;
		boxShapeDesc->pGeometry = new physx::PxBoxGeometry(halfSize);
		boxShapeDesc->pose = px3Cast<physx::PxTransform>(m_physInfo.transform);
		/*physx::PxBoxGeometry box;
		boxShapeDesc->getBoxGeometry(box);
		box.halfExtents = halfSize;
		boxShapeDesc->setGeometry(box);   
		//= physx::PxShape::getActor();
		//boxShapeDesc->se >dimensions = halfSize;*/
		shapeDesc = (physx::PxShape*) boxShapeDesc;
		ColShapes.push_back(boxShapeDesc);
	}
	else if (m_physInfo.shapeType == PhysInfo::ST_SPHERE)
	{
		Px3CollisionDesc *sphereShapeDesc = new Px3CollisionDesc;
		Px3CollisionDesc *desc = new Px3CollisionDesc;
		desc->pGeometry = new physx::PxSphereGeometry(0.5f * m_physInfo.params.x);
		desc->pose = px3Cast<physx::PxTransform>(m_physInfo.transform);
		/*
		physx::PxSphereGeometry sphere;
		sphereShapeDesc->setGeometry(sphere);
		sphere.radius *= ;*/
		shapeDesc = (physx::PxShape*) sphereShapeDesc;
		ColShapes.push_back(sphereShapeDesc);
	}
	else if (m_physInfo.shapeType == PhysInfo::ST_CAPSULE || m_physInfo.shapeType == PhysInfo::ST_CYLINDER)
	{
		//rotate on pi/2
		static bool useRot = true;
		if (useRot)
		{
			MatrixF rotMat(EulerF(float(M_PI)/2.f,0.f,0.f));
			m_physInfo.transform.mul(rotMat);
			mTransformInv = m_physInfo.transform;
			mTransformInv.inverse();
		}
		Px3CollisionDesc *capsuleShapeDesc = new Px3CollisionDesc;
		
		physx::PxVec3 sizes = vectorToPx(m_physInfo.params);
		F32 radius = 0.5f*sizes.x;
		F32 halfHeight = sizes.z - sizes.x > 0 ? sizes.z - sizes.x : 0.1f;
		capsuleShapeDesc->pGeometry = new physx::PxCapsuleGeometry(radius,halfHeight);//uses half height
		capsuleShapeDesc->pose = px3Cast<physx::PxTransform>(m_physInfo.transform);
		shapeDesc = (physx::PxShape*) capsuleShapeDesc;
		ColShapes.push_back(capsuleShapeDesc);
		/*
		physx::PxShape* capsuleShapeDesc;
		physx::PxCapsuleGeometry capsule;	
		capsuleShapeDesc->setGeometry(capsule);
		*/		
	}
	else
	{
		Con::errorf("PhysShapeBullet::PhysShapeBullet(): Wrong phys type %d",int(m_physInfo.shapeType));
	}
	
	AssertFatal(shapeDesc,"Can't create physic collision shape ");

	Px3CollisionDesc *actorDesc = new Px3CollisionDesc;
	ColShapes.push_back(actorDesc);	

	m_actor = gPhysics3SDK->createRigidDynamic(physx::PxTransform(physx::PxIDENTITY())); // gPhysics3SDK 1st call
		physx::PxRigidDynamic *actor = m_actor->is<physx::PxRigidDynamic>(); // actually a PxRigidActor
		actor->setRigidDynamicFlag(physx::PxRigidDynamicFlag::eKINEMATIC, true); // flags
		actor->setMass(getMax( m_physInfo.mass, 1.0f )); // flags

	//m_scene->addActor(actorDesc);

	m_actor->userData = &mUserData;
}


PhysShapePhysX::~PhysShapePhysX()
{
	m_world->lockScene();
	m_actor->userData = NULL;
	m_scene->removeActor(*m_actor);
	m_actor = NULL;
	//m_material->release(); // this could be important
	m_world->unlockScene();
}

void PhysShapePhysX::setPhysicTransform(const MatrixF& tr)
{
	m_actor->setGlobalPose(px3Cast<physx::PxTransform>(tr),false);
}

void PhysShapePhysX::getPhysicTransform(MatrixF & tr)
{
	tr = px3Cast<MatrixF>(m_actor->getGlobalPose());
}

VectorF PhysShapePhysX::getLinVelocity()
{
	physx::PxRigidDynamic *actor = m_actor->is<physx::PxRigidDynamic>();
	return px3Cast<Point3F>( actor->getLinearVelocity() );
	/*
	VectorF res = vectorFromPx(m_actor->getLinearVelocity());
	return res;*/
}

void PhysShapePhysX::setLinVelocity(const VectorF& vel)
{
	m_actor->is<physx::PxRigidDynamic>();
	m_actor->setLinearVelocity( px3Cast<physx::PxVec3>(vel));
}

VectorF PhysShapePhysX::getAngVelocity()
{
	VectorF res = vectorFromPx(m_actor->getAngularVelocity());
	return res;
}

void PhysShapePhysX::setAngVelocity(const VectorF& vel)
{
	m_actor->setAngularVelocity(vectorToPx(vel));
}

void PhysShapePhysX::addForce(const VectorF& f)
{
	physx::PxVec3 force = vectorToPx(f);
	m_actor->addForce(force);
}

void PhysShapePhysX::addForce(const VectorF& fForce, const Point3F& pOrigin)
{
	m_world->lockScene();
	/*physx::PxVec3 force = vectorToPx(fForce);
	physx::PxVec3 pos = vectorToPx(pOrigin);

	static physx::PxF32 scaler = 1.f;
	force = force*scaler;
	*/
	physx::PxRigidDynamic *actor = m_actor->is<physx::PxRigidDynamic>();
	physx::PxRigidBodyExt::addForceAtPos(*actor,px3Cast<physx::PxVec3>(fForce),
												px3Cast<physx::PxVec3>(pOrigin),
												physx::PxForceMode::eIMPULSE);
	m_world->unlockScene();

	//m_actor-> >addForceAtPos( force, pos);
}

void PhysShapePhysX::reset()
{

}


void PhysShapePhysX::setForce(const VectorF& force)
{
	//m_actor->setAngularVelocity(vectorToPx(force));
	m_actor->is<physx::PxRigidDynamic>();
	m_actor->setAngularVelocity( vectorToPx(force) );
}

VectorF  PhysShapePhysX::getForce()
{
	/*VectorF res = vectorFromPx(m_actor->getLinearMomentum());
	return res;*/
	physx::PxRigidDynamic *actor = m_actor->is<physx::PxRigidDynamic>();
	return px3Cast<Point3F>( actor->getAngularVelocity() );
}
void  PhysShapePhysX::setTorque(const VectorF& torque)
{
	//m_actor->s >setAngularMomentum(vectorToPx(torque));
	physx::PxRigidDynamic *actor = m_actor->is<physx::PxRigidDynamic>();
	actor->setAngularVelocity( vectorToPx(torque) );
}
VectorF  PhysShapePhysX::getTorque()
{
	physx::PxRigidDynamic *actor = m_actor->is<physx::PxRigidDynamic>();
	
	return px3Cast<Point3F>( actor->getAngularVelocity() );
}

void PhysShapePhysX::setEnable(bool isEnabled)
{
	m_world->lockScene();
	if (isEnabled)
	{
		m_actor->setActorFlag(physx::PxActorFlag::eDISABLE_GRAVITY, true);// >clearActorFlag ( NX_AF_DISABLE_COLLISION );
		m_actor->setActorFlag(physx::PxActorFlag::eDISABLE_SIMULATION, true );
		m_actor->wakeUp();

		U32 shapeCount = m_actor->getNbShapes();
		physx::PxShape **pShapeArray = new physx::PxShape*[shapeCount];
		
		for ( S32 i = 0; i < shapeCount; i++ )      
			pShapeArray[i]->setFlag( physx::PxShapeFlag::eSIMULATION_SHAPE, false );

	}
	else
	{
		m_actor->setActorFlag(physx::PxActorFlag::eDISABLE_GRAVITY, true);// >clearActorFlag ( NX_AF_DISABLE_COLLISION );
		m_actor->setActorFlag(physx::PxActorFlag::eDISABLE_SIMULATION, true );
		m_actor->putToSleep();

		U32 shapeCount = m_actor->getNbShapes();
		physx::PxShape **pShapeArray = new physx::PxShape*[shapeCount];

		for ( U32 i = 0; i < shapeCount; i++ )      
			pShapeArray[i]->setFlag( physx::PxShapeFlag::eSIMULATION_SHAPE, false );      
	}
	m_world->unlockScene();

}

bool PhysShapePhysX::isEnabled()
{	
	return !m_actor->getActorFlags();// >readActorFlag(NX_AF_DISABLE_COLLISION);
}

bool PhysShapePhysX::isActive()
{	
	return !m_actor->isSleeping();
}
void PhysShapePhysX::setActive(bool flg)
{	
	if (flg)
		m_actor->wakeUp();
	else
		m_actor->putToSleep();
}
