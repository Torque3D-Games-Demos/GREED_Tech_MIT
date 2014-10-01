//-----------------------------------------------------------------------------
// Copyright 2013-2014 Galmateon-Studios, All rights reserved.
//-----------------------------------------------------------------------------
//--
#ifndef _PHYSICSPHYSX_H_
#define _PHYSICSPHYSX_H_

#include "T3D/logickingMechanics/physics/physics.h"
#undef min
#undef max
#include "T3D/physics/physicsPlugin.h"
#include "T3D/physics/physx3/px3World.h"

class PhysicsPhysX: public Physics
{
public:
	static Physics* createPhysicsX(PhysicsWorld* world);

	PhysicsPhysX(PhysicsWorld* world);
	virtual ~PhysicsPhysX();

	virtual PhysShape* createPhysShape(const PhysInfo& descr);
	virtual PhysShape* createPhysShape(void* vBuffer,int vNum,int vStride, 
											void* iBuffer, int iNum, int triStride);

	//virtual PhysJoint* createPhysJoint(PhysJointInfo& descr);
	//virtual PhysShape* createPhysShapeSoft(const PhysSoftInfo& descr);

	physx::PxScene *getPhysScene() {return mScene;};
	Px3World *getWorld() {return mWorld;};

private:
	Px3World *mWorld;
	physx::PxScene *mScene;

	static void initPhysX();
	/*
	static float m_restitution;
	static float m_staticFriction;
	static float m_dynamicFriction;
	*/
};
physx::PxVec3 vectorToPx(const VectorF & v);
VectorF vectorFromPx(const physx::PxVec3 & v);

/* i declare this deprecated for physx 3 */
/*
NxMat34 matrixToPx(const MatrixF & m);
MatrixF matrixFromPx(const NxMat34 & m);
*/

#endif