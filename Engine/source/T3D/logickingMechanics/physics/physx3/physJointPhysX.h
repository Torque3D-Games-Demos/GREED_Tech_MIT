//-----------------------------------------------------------------------------
// Copyright 2013-2014 Galmateon-Studios, All rights reserved.
//-----------------------------------------------------------------------------
//--
#ifndef _PHYSJOINTPHYSX_H_
#define _PHYSJOINTPHYSX_H_

#include "T3D/logickingMechanics/physics/physJoint.h"
#include "T3D/logickingMechanics/physics/physX/physShapePhysX.h"

class PhysJointPhysX : public PhysJoint
{
public:
	PhysJointPhysX();
	PhysJointPhysX(Physics* phys,PhysJointInfo &physJointDescr);
	virtual ~PhysJointPhysX();
protected:
	Px3World* m_world;
	physx::PxScene* m_scene;
	physx::PxJoint* m_joint;
};

#endif