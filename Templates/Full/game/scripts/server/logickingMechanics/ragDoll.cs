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

//-----------------------------------------------------------------------------
function RagDollData::create(%block)
{   
	// The mission editor invokes this method when it wants to create   
	// an object of the given datablock type.   
	%obj = new RagDoll()   {    dataBlock = %block;   };   
	return %obj;
}


function createRagDoll(%ragdollData, %obj)
{
   %ragDoll_obj = new RagDoll()
            {
					position = "0 0 0";
					rotation = "1 0 0 0";
					dataBlock = %ragdollData;
				};
				
   %ragDoll_obj.initRagDoll(%obj);
   
   %force = VectorSub(%obj.getPosition(), %obj.damagePos);
   %force = setWord(%force,2,0);
   %force = VectorNormalize(%force);
   %force = VectorScale(%force,6500);
   %ragDoll_obj.applyImpulse(%obj.damagePos,%force);
   //%ragDoll_obj.applyImpulse(%obj.damagePos, "1500 0 0");

   %ragDoll_obj.schedule($CorpseTimeoutValue - 1000, "startFade", 1000, 0, true);
   %ragDoll_obj.schedule($CorpseTimeoutValue, "delete");

   return %ragDoll_obj;
}


//-----------------------------------------------------------------------------
// for Game Mechanics Editor
//-----------------------------------------------------------------------------
activatePackage(TemplateFunctions);
registerTemplate("AbstractRagDollBody", "AbstractsPhysics", "");
setTemplateAction("AbstractRagDollBody", "setEnabled", "(%isEnabled)");
deactivatePackage(TemplateFunctions);


//test
function cro()
{
   new AIBot(orc) {
      dataBlock = "SoldierBotData";
      position = "530 660 256.41";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      canSave = "1";
      canSaveDynamicFields = "1";
      Enabled = "1";
         blockMovement = "false";
         category = "AI";
         editorIcon = "tools/LogickingEditor/images/AI";
         guardCloseDist = "3";
         guardFarDist = "5";
         Health = "100";
         invBlasterAmmo = "3000";
         Item = "HealthPatch";
         perceptionEnabled = "false";
         templateName = "SoldierBot";
         viewDist = "40";
   };
}
function ite()
{
 new Item(ite) {
			position = "530 660 256.41";
			rotation = "1 0 0 0";
			dataBlock = "HealthPatch";
			rotate = true;
		};
}
		
function en()
{
	orc.setEnemy($playerForAi);
}

function sh()
{
	orc.setImageTrigger(0,true);
	orc.setImageTrigger(0,false);
}

function de()
{
	orc.delete();
}

function rag()
{
		new RagDoll( rd)
            {
					position = "530 660 256.41";
					rotation = "1 0 0 0";
					dataBlock = SoldierRagDoll;
		};
}

function bar()
{
	   new StaticShape(bar) {
      receiveSunLight = "1";
      receiveLMLighting = "1";
      useCustomAmbientLighting = "0";
      customAmbientLighting = "0 0 0 1";
      dataBlock = "SteelBarrel";
      position =  "530 660 256.41";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      canSaveDynamicFields = "1";
      class = "Breakable";
      className = "Breakable";
      Enabled = "1";
         category = "Breakables";
         Collision = "0";
         editorIcon = "tools/missionEditor/images/LogickingEditor/Breakable";
         health = "60";
         healthBound = "50";
         templateName = "SteelBarrel";
   };
}

//test ai
function pauseGame(%val)
{
	if ((%val) || (%val $= ""))
	{
		if ($timeScale != 0)
		{
			$timeScale = 0;
		}
		else
			$timeScale = 1;
	}
}
GlobalActionMap.bind(keyboard, pause, pauseGame);
