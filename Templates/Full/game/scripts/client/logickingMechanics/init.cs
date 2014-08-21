//-----------------------------------------------------------------------------
// Copyright (C) LogicKing.com, Inc.
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

GlobalActionMap.bind(keyboard, "e", useObject);

// Used to call "use" method
function useObject(%flg)
{    
    commandToServer('useObj', %flg);
}

function clientCmdUpdateUseIcon(%isUsable)
{
	if(%isUsable)
	{
        crossHair.setVisible(false);
        useCrossHair.setVisible(true);
	}
	else
	{
        crossHair.setVisible(true);
        useCrossHair.setVisible(false);
	}
} 

addMessageCallback( 'MsgDoorLocked', handleDoorLocked );


function GameMessageText::hideText()
{
	GameMessageText.needToHide = GameMessageText.needToHide - 1;
	if(GameMessageText.needToHide == 0)
		GameMessageText.setVisible(false);
	
}

function handleDoorLocked(%msgType, %msgString)
{
   GameMessageText.setVisible(true);
   GameMessageText.setText(detag(%msgString));
   GameMessageText.needToHide = GameMessageText.needToHide $="" ? 0 : GameMessageText.needToHide;
   GameMessageText.needToHide = GameMessageText.needToHide + 1;
   GameMessageText.schedule(4000, hideText);
}