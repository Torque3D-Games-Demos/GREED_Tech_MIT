//-----------------------------------------------------------------------------
// Copyright 2008 (C) LogicKing.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _PHYSSHAPEBULLET_H_
#define _PHYSSHAPEBULLET_H_

#include "T3D/logickingMechanics/physics/physX/physicsPhysX.h"
#include "T3D/logickingMechanics/physics/physShape.h"
#include "T3D/physics/physx3/px3Collision.h"

namespace physx{
	class PxRigidActor;
	class PxMaterial;
	class PxShape;
}

class PhysShapePhysX: public PhysShape
{
public:
	friend class Px3Collision;
	PhysShapePhysX(Physics* phys, const PhysInfo &physDescr);
	virtual ~PhysShapePhysX();

	virtual VectorF	getLinVelocity();
	virtual void	setLinVelocity(const VectorF& vel);

	virtual VectorF	getAngVelocity();
	virtual void	setAngVelocity(const VectorF& vel);

	virtual void	setForce(const VectorF& force);
	virtual VectorF getForce();
	virtual void	setTorque(const VectorF& torque);
	virtual VectorF getTorque();

	virtual void	addForce(const VectorF& force);
	virtual void	addForce(const VectorF& force, const Point3F& pos);
	virtual void	reset();

	virtual void	setEnable(bool isEnabled);
	virtual bool	isEnabled();
	virtual bool	isActive();
	virtual void	setActive(bool flg);
	typedef Vector<Px3CollisionDesc*> pColList;
	
	physx::PxRigidDynamic*	getActor(){return m_actor;};
	//U32	mMflags;
protected:
	virtual void	setPhysicTransform(const MatrixF&);
	virtual void	getPhysicTransform(MatrixF &);
	pColList ColShapes;
	/// The body flags set at creation time.
   U32 mBodyFlags;

   /// Is true if this body is enabled and active
   /// in the simulation of the scene.
   bool mIsEnabled;
   bool mIsStatic;
	
private:
	MatrixF mTm;
	/* px3 removal ? */
	Px3World *m_world;
	physx::PxScene* m_scene;
	physx::PxRigidDynamic *m_actor;
	// might be needed 
	physx::PxMaterial *m_material;
};

#endif