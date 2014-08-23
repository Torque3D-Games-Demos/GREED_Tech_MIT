//-----------------------------------------------------------------------------
// Copyright (C) 2014 J0linar [7Sins]
// Copyright (C) Logicking.com, Inc.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------
// Sample rag dolls for physx
//-----------------------------------------------------------------------------

//shape $ShapeType::Box,$ShapeType::Sphere, $ShapeType::Capsule - 2   
//joint $JointType::ConeTwist, $JointType::Hinge, $JointType::Dof6", $JointType::BallSocket"

datablock RagDollData(SoldierRagDoll) 
{
	category = "RigidBody";
	shapeFile = "art/shapes/actors/Soldier/soldier_rigged.dae";
	
	minContactSpeed = 5.0;
	slidingThreshold = 0.5;
	collisionSoundsCount = 1;
	collisionSound[0] = bodyFall0;

    //pelvis
	boneNodeName[0] = "Bip01_Pelvis";
	boneSize[0] = "0.4 0.1 0.0";
	boneMass[0] = 1;
	boneShape[0] = $ShapeType::Capsule;
	boneOffset[0] = "0 0 0";


	//torso	
	boneParentNodeName[1] = "Bip01_Pelvis";
	boneNodeName[1] = "Bip01_Spine2";
	boneSize[1] = "0.2 0.2 0.0";
	boneMass[1] = 1;
	boneShape[1] = $ShapeType::Capsule;
	boneJointType[1] = $JointType::Hinge;
	boneOffset[1] = "0 0 0";
	boneJointParam[1] = "0 1.57 0";
	
		
	//head
	boneParentNodeName[2] = "Bip01_Spine2";
	boneNodeName[2] = "Bip01_Head";
	boneSize[2] = "0.2 0.1 0.0";
	boneMass[2] = 0.1;
	boneShape[2] = $ShapeType::Capsule;
	boneOffset[2] = "0 0 0";
	boneJointType[2] = $JointType::ConeTwist;
	boneJointParam[2] = "0.785 -0.785 0.785";

	//left arm
	//L_upperarm
	boneParentNodeName[3] = "Bip01_Spine2";
	boneNodeName[3] = "Bip01_L_UpperArm";
	boneSize[3] = "0.2 0.3 0.0";
	boneMass[3] = 1;//5;
	boneShape[3] = $ShapeType::Capsule;
	boneOffset[3] = "0 0 0";
	boneJointType[3] = $JointType::ConeTwist;
	boneJointParam[3] = "0.785 -0.785 0.785";
	
	//L_forearm		
	boneParentNodeName[4] = "Bip01_L_UpperArm";
	boneNodeName[4] = "Bip01_L_Forearm";
	boneSize[4] = "0.2 0.4 0.0";
	boneMass[4] = 1;
	boneShape[4] = $ShapeType::Capsule;
	boneOffset[4] = "0 0 0";
	boneJointType[4] = $JointType::Hinge;
	boneJointParam[4] = "-1.57 0 0";
	
	//L_hand
	boneParentNodeName[5] = "Bip01_L_Forearm";
	boneNodeName[5] = "Bip01_L_Hand";
	boneSize[5] = "0.2 0.1 0.0";
	boneMass[5] = 0.1;
	boneShape[5] = $ShapeType::Capsule;
	boneOffset[5] = "0 0 0";
	boneJointType[5] = $JointType::ConeTwist;
	boneJointParam[5] = "0.785 -0.785 0.785";
	
	//right arm
	//R_upperarm
	boneParentNodeName[6] = "Bip01_Spine2";
	boneNodeName[6] = "Bip01_R_UpperArm";
	boneSize[6] = "0.2 0.3 0.0";
	boneMass[6] = 1;
	boneShape[6] = $ShapeType::Capsule;
	boneOffset[6] = "0 0 0";
	boneJointType[6] = $JointType::ConeTwist;
	boneJointParam[6] = "0.785 -0.785 0.785";
	
	//R_forearm	
	boneParentNodeName[7] = "Bip01_R_UpperArm";
	boneNodeName[7] = "Bip01_R_Forearm";
	boneSize[7] = "0.2 0.4 0.0";
	boneMass[7] = 1;
	boneShape[7] = $ShapeType::Capsule;
	boneOffset[7] = "0 0 0";
	boneJointType[7] = $JointType::Hinge;
	boneJointParam[7] = "-1.57 0 0";
	
	//R_hand
	boneParentNodeName[8] = "Bip01_R_Forearm";
	boneNodeName[8] = "Bip01_R_Hand";
	boneSize[8] = "0.2 0.1 0.0";
	boneMass[8] = 0.1;
	boneShape[8] = $ShapeType::Capsule;
	boneOffset[8] = "0 0 0";
	boneJointType[8] = $JointType::ConeTwist;
	boneJointParam[8] = "0.785 -0.785 0.785";
	
	//left leg
	//upper
	boneParentNodeName[9] = "Bip01_Pelvis";
	boneNodeName[9] = "Bip01_L_Thigh";
	boneSize[9] = "0.2 0.4 0.0";
	boneMass[9] = 1;
	boneShape[9] = $ShapeType::Capsule;
	boneOffset[9] = "0 0 0";
	boneJointType[9] = $JointType::ConeTwist;
	boneJointParam[9] = "0.785 -0.785 0.785";
	//lower	
	
	boneParentNodeName[10] = "Bip01_L_Thigh";
	boneNodeName[10] = "Bip01_L_Calf";
	boneSize[10] = "0.2 0.4 0.0";
	boneMass[10] = 0.75;
	boneShape[10] = $ShapeType::Capsule;
	boneOffset[10] = "0 0 0";
	boneJointType[10] = $JointType::Hinge;
	boneJointParam[10] = "-1.57 0 0";
	
	boneParentNodeName[11] = "Bip01_L_Calf";
	boneNodeName[11] = "Bip01_L_Foot";
	boneSize[11] = "0.2 0.4 0.0";
	boneMass[11] = 0.5;
	boneShape[11] = $ShapeType::Capsule;
	boneOffset[11] = "0 0 0";
	boneJointType[11] = $JointType::Hinge;
	boneJointParam[11] = "-1.57 0 0";
	
	boneParentNodeName[12] = "Bip01_L_Foot";
	boneNodeName[12] = "Bip01_L_Toe0";
	boneSize[12] = "0.2 0.4 0.0";
	boneMass[12] = 0.25;
	boneShape[12] = $ShapeType::Capsule;
	boneOffset[12] = "0 0 0";
	boneJointType[12] = $JointType::Hinge;
	boneJointParam[12] = "-1.57 0 0";
	
	//right leg
	//upper
	boneParentNodeName[13] = "Bip01_Pelvis";
	boneNodeName[13] = "Bip01_R_Thigh";
	boneSize[13] = "0.2 0.4 0.0";
	boneMass[13] = 1;//7;
	boneShape[13] = $ShapeType::Capsule;
	boneOffset[13] = "0 0 0";
	boneJointType[13] = $JointType::ConeTwist;
	boneJointParam[13] = "0.785 -0.785 0.785";
	//lower
	
	boneParentNodeName[14] = "Bip01_R_Thigh";
	boneNodeName[14] = "Bip01_R_Calf";
	boneSize[14] = "0.2 0.4 0.0";
	boneMass[14] = 0.75;
	boneShape[14] = $ShapeType::Capsule;
	boneOffset[14] = "0 0 0";
	boneJointType[14] = $JointType::Hinge;
	boneJointParam[14] = "-1.57 0 0";
	
	boneParentNodeName[15] = "Bip01_R_Calf";
	boneNodeName[15] = "Bip01_R_Foot";
	boneSize[15] = "0.2 0.4 0.0";
	boneMass[15] = 0.5;
	boneShape[15] = $ShapeType::Capsule;
	boneOffset[15] = "0 0 0";
	boneJointType[15] = $JointType::Hinge;
	boneJointParam[15] = "-1.57 0 0";
	
	boneParentNodeName[16] = "Bip01_R_Foot";
	boneNodeName[16] = "Bip01_R_Toe0";
	boneSize[16] = "0.2 0.4 0.0";
	boneMass[16] = 0.25;
	boneShape[16] = $ShapeType::Capsule;
	boneOffset[16] = "0 0 0";
	boneJointType[16] = $JointType::Hinge;
	boneJointParam[16] = "-1.57 0 0";
};

// To inherit from the SoldierRagdoll, your model should have the same bone
// naming and the same bone order, if not then you should create a new entry
// and tweak ragdoll from boneParentNode to boneNode!
//
//datablock RagDollData(YourModelRagDoll : SoldierRagDoll) 
//{
	//shapeFile = "art/shapes/actors/YourModel/YourModel.dts";
//};
