//-----------------------------------------------------------------------------
// Logicking's Game Factory
// Copyright (C) Logicking.com, Inc.
//-----------------------------------------------------------------------------
// Sample rag dolls for bullet
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
	boneMass[0] = 1;//25;
	boneShape[0] = $ShapeType::Capsule;
	boneOffset[0] = "0 0 0";


	//torso	
	boneParentNodeName[1] = "Bip01_Pelvis";
	boneNodeName[1] = "Bip01_Spine2";
	boneSize[1] = "0.2 0.2 0.0";
	boneMass[1] = 1;//25;
	boneShape[1] = $ShapeType::Capsule;
	boneJointType[1] = $JointType::Hinge;
	boneOffset[1] = "0 0 0";
	boneJointParam[1] = "0 1.57 0";//-0.785//"1.57 3.14 0"
	
		
	//head
	boneParentNodeName[2] = "Bip01_Spine2";
	boneNodeName[2] = "Bip01_Head";
	boneSize[2] = "0.2 0.1 0.0";
	boneMass[2] = 1;//5;
	boneShape[2] = $ShapeType::Capsule;
	boneOffset[2] = "0 0 0";
	boneJointType[2] = $JointType::ConeTwist;//1;//
	boneJointParam[2] = "0.785 0.785 0";//"0 0 0";//"0.785 0.785 1.57";//

	//left arm
	//upperarm
	boneParentNodeName[3] = "Bip01_Spine2";
	boneNodeName[3] = "Bip01_L UpperArm";
	boneSize[3] = "0.2 0.3 0.0";
	boneMass[3] = 1;//5;
	boneShape[3] = $ShapeType::Capsule;
	boneOffset[3] = "0 0 0";
	boneJointType[3] = $JointType::ConeTwist;//1;//3;//
	boneJointParam[3] = "0.785 0.785 0";
	//forearm		
	boneParentNodeName[4] = "Bip01_L UpperArm";
	boneNodeName[4] = "Bip01_L Forearm";
	boneSize[4] = "0.2 0.4 0.0";
	boneMass[4] = 1;//5;
	boneShape[4] = $ShapeType::Capsule;
	boneOffset[4] = "0 0 0";
	boneJointType[4] = $JointType::Hinge;
	boneJointParam[4] = "-1.57 0 0";//"0 1.57 0";
	
	
	//right arm
	//upperarm
	boneParentNodeName[5] = "Bip01_Spine2";
	boneNodeName[5] = "Bip01_R UpperArm";
	boneSize[5] = "0.2 0.3 0.0";
	boneMass[5] = 1;//5;
	boneShape[5] = $ShapeType::Capsule;
	boneOffset[5] = "0 0 0";
	boneJointType[5] = $JointType::ConeTwist;//1;//3;//
	boneJointParam[5] = "0.785 0.785 0";
	//forearm	
	boneParentNodeName[6] = "Bip01_R UpperArm";
	boneNodeName[6] = "Bip01_R Forearm";
	boneSize[6] = "0.2 0.4 0.0";
	boneMass[6] = 1;//5;
	boneShape[6] = $ShapeType::Capsule;
	boneOffset[6] = "0 0 0";
	boneJointType[6] = $JointType::Hinge;
	boneJointParam[6] = "-1.57 0 0";//"0 1.57 0";

	//left leg
	//upper
	boneParentNodeName[7] = "Bip01_Pelvis";
	boneNodeName[7] = "Bip01_L Thigh";
	boneSize[7] = "0.2 0.4 0.0";
	boneMass[7] = 1;//7;
	boneShape[7] = $ShapeType::Capsule;
	boneOffset[7] = "0 0 0";
	boneJointType[7] = $JointType::ConeTwist;//1;//
	boneJointParam[7] = "0.785 0.785 0";
	//lower	
	
	boneParentNodeName[8] = "Bip01_L Thigh";
	boneNodeName[8] = "Bip01_L Calf";
	boneSize[8] = "0.2 0.4 0.0";
	boneMass[8] = 1;//7;
	boneShape[8] = $ShapeType::Capsule;
	boneOffset[8] = "0 0 0";
	boneJointType[8] = $JointType::Hinge;
	boneJointParam[8] = "-1.57 0 0";

	//right leg
	//upper
	boneParentNodeName[9] = "Bip01_Pelvis";
	boneNodeName[9] = "Bip01_R Thigh";
	boneSize[9] = "0.2 0.4 0.0";
	boneMass[9] = 1;//7;
	boneShape[9] = $ShapeType::Capsule;
	boneOffset[9] = "0 0 0";
	boneJointType[9] = $JointType::ConeTwist;//1;//
	boneJointParam[9] = "0.785 0.785 0";
	//lower
	
	boneParentNodeName[10] = "Bip01_R Thigh";
	boneNodeName[10] = "Bip01_R Calf";
	boneSize[10] = "0.2 0.4 0.0";
	boneMass[10] = 1;//7;
	boneShape[10] = $ShapeType::Capsule;
	boneOffset[10] = "0 0 0";
	boneJointType[10] = $JointType::Hinge;
	boneJointParam[10] = "-1.57 0 0";
};

// To inherit from the SoldierRagdoll, your model should have the same bone
// naming, if not then you should create a new entry
//datablock RagDollData(YourModelRagDoll : SoldierRagDoll) 
//{
	//shapeFile = "art/shapes/actors/YourModel/YourModel.dts";
//};