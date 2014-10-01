//-----------------------------------------------------------------------------
// Copyright 2013-2014 Galmateon-Studios, All rights reserved.
//-----------------------------------------------------------------------------
//--

#include "T3D/logickingMechanics/physics/physBody.h"
#include "T3D/logickingMechanics/physics/physx/physicsPhysX.h"
#include "T3D/logickingMechanics/physics/physx/physShapePhysX.h"
/*#include "T3D/logickingMechanics/physics/physx/physJointPhysX.h"
#include "T3D/logickingMechanics/physics/physx/physShapeSoftPhysX.h"


float PhysicsPhysX::m_restitution = 0.0f;
float PhysicsPhysX::m_staticFriction = 0.4f;
float PhysicsPhysX::m_dynamicFriction = 0.4f;*/

Physics* PhysicsPhysX::createPhysicsX(PhysicsWorld* world)
{
	Physics* physics =  (Physics*) new PhysicsPhysX(world);
	return physics;
}

void PhysicsPhysX::initPhysX()
{

	/*
	const char* restitution =  Con::getVariable("$GMK::Physics::PhysX::restitution");
	const char* staticFriction =  Con::getVariable("$GMK::Physics::PhysX::staticFriction");
	const char* dynamicFriction =  Con::getVariable("$GMK::Physics::PhysX::dynamicFriction");
	m_restitution = dStrcmp(restitution,"") ? dAtof(restitution) : m_restitution;
	m_staticFriction = dStrcmp(staticFriction,"") ? dAtof(staticFriction) : m_staticFriction;
	m_dynamicFriction = dStrcmp(dynamicFriction,"") ? dAtof(dynamicFriction) : m_dynamicFriction;
	*/
}

PhysicsPhysX::PhysicsPhysX(PhysicsWorld* world)
{
	//initPhysX();
	//Px3World *px3World = dynamic_cast<Px3World*>( PHYSICSMGR->getWorld( "client" ) ); //static_cast<Px3World*>(world);
	mWorld = (Px3World*)world;
	mScene = mWorld->getScene();

	//set default material params
	/* not needed with physx3 plugin ? */
	/*
	physx::PxMaterial* defaultMaterial;
	physx::PxPhysics::getMaterials(&defaultMaterial, 1); // = mScene->getMaterialFromIndex(0); 	
	defaultMaterial->setRestitution(m_restitution);
	defaultMaterial->setStaticFriction(m_staticFriction);
	defaultMaterial->setDynamicFriction(m_dynamicFriction);
	*/
}

PhysicsPhysX::~PhysicsPhysX()
{
	mWorld = NULL;
	mScene = NULL;
}

PhysShape* PhysicsPhysX::createPhysShape(const PhysInfo& descr)
{
	PhysShape* physShape = (PhysShape*) new PhysShapePhysX(this,descr);
	return physShape;
}

PhysShape* PhysicsPhysX::createPhysShape(void* vBuffer,int vNum,int vStride, 
						   void* iBuffer, int iNum, int triStride)
{
	return NULL;
}

/* commented out for ref ing that shit away from existence (EW code) */
/*
PhysJoint* PhysicsPhysX::createPhysJoint(PhysJointInfo& descr)
{
	PhysJoint* physJoint = (PhysJoint*) new PhysJointPhysX(this,descr);
	return physJoint;
}

PhysShape* PhysicsPhysX::createPhysShapeSoft(const PhysSoftInfo& descr)
{
	PhysShape* physShape = (PhysShape*) new PhysShapeSoftPhysX(this,descr);
	return physShape;
}
*/

VectorF vectorFromPx(const physx::PxVec3 & v)
{
	return VectorF(v.x,v.y,v.z);
}

physx::PxVec3 vectorToPx(const VectorF & v)
{
	return physx::PxVec3(v.x,v.y,v.z);
}

/* i declare this deprecated for physx 3 */
/*

MatrixF matrixFromPx(const physx::PxMat44 & m)
{
	MatrixF res;
	m.column0( res );// getRowMajor44( res );
	return res;
}

NxMat34 matrixToPx(const MatrixF & m)
{
	NxMat34 res;
	res.setRowMajor44( m );
	return res;
}
*/