//-----------------------------------------------------------------------------
// Copyright (C) LogicKing.com, Inc.
//-----------------------------------------------------------------------------
// Soldier Bot
//-----------------------------------------------------------------------------

exec("art/shapes/actors/Soldier/soldier_rigged.cs");


datablock SFXDescription(AudioScream3d)
{
   volume   = 1.0;
   isLooping = false;

   is3D = true;
   ReferenceDistance = 40.0;
   MaxDistance = 80.0;
   channel = $SimAudioType;
};

datablock SFXProfile(SoldierSoundDeath)
{
   fileName = "art/sound/Soldier_death";
   description = AudioScream3d;
   preload = true;
};


datablock SFXProfile(SoldierSoundPain01)
{
   fileName = "art/sound/Soldier_pain_01";
   description = AudioScream3d;
   preload = true;
};

datablock SFXProfile(SoldierSoundPain02)
{
   fileName = "art/sound/Soldier_pain_02";
   description = AudioScream3d;
   preload = true;
};



datablock PlayerData(SoldierBotData : DefaultPlayerData)
{
   renderFirstPerson = false;
   emap = true;
   
   jumpTowardsNormal = false;
   airControl = 0;
   
   maxForwardSpeed = 7;
   maxBackwardSpeed = 5; 
   maxSideSpeed = 5;
   jumpForce = 30.0 * 90;

   shapeFile = "art/shapes/actors/Soldier/soldier_rigged.dae";
   
   category = "AI";
   className = "AiBotData";
   
   deathSnd = SoldierSoundDeath;
   painSnd[0] = SoldierSoundPain01;
   painSnd[1] = SoldierSoundPain02;
   painSndCount = 2;
   
   ragdoll = "SoldierRagDoll";
   
   weapon = BlasterGunImage;
   ammo = BlasterAmmo;
   ammoCount = 3000;
   //shootingDelay = 2000;
   
   shootingDelay = 500;
   shootingDelayVariant = 400;
   
   
   chaseFarDist = 20;
   chaseCloseDist = 14;
   attackFov = 45;
   attackDist = 50;
   
   strafeMinDist = 5;
   strafeMaxDist = 10;
   strafeChangeDirTime = 800;
   
   maxDamage = 50;//10000;
   
   maxInv[BlasterAmmo] = 5000;
};

datablock PlayerData(SoldierBotData2 : SoldierBotData)
{
   weapon = RocketLauncherImage;
   ammo = RocketLauncherAmmo;
   ammoCount = 3000;
   shootingDelay = 2000;
   shootingDelayVariant = 2000;
};

//-----------------------------------------------------------------------------
// for Game Mechanics Editor
//-----------------------------------------------------------------------------
activatePackage(TemplateFunctions);
inheritTemplate("SoldierBot", "AiBot");
registerTemplate("SoldierBot", "AI", "AiBotData::create(SoldierBotData); ");
setTemplateField("SoldierBot", "health", "100");
setTemplateField("SoldierBot", "item", "HealthPatch", "", "Misc", "An item that bot spawns on his death.");
deactivatePackage(TemplateFunctions);