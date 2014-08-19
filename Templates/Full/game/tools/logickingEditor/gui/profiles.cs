//-----------------------------------------------------------------------------
// Copyright (C) LogicKing.com
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

singleton GuiControlProfile (LogicMechanicsGuiRollOutProfile)
{
   fontType    = "Arial";
   fontSize    = "14";
   
   fontColor = "0 0 0 150";
   fontColorHL = "25 25 25 220";
   fontColorNA = "128 128 128";
   
   justify = "left";
   opaque = true;
   border = 1;
   cankeyfocus=true;
   tab = true;
  
   //bitmap = "tools/editorclasses/gui/images/rollout";
   bitmap = "tools/editorClasses/gui/panels/inspector-stlyle-rollout";   
   
   textOffset = "30 0";

};

singleton GuiControlProfile (LogicMechanicsAboutTextProfile22)
{
   fontColor = "0 0 0";
   fontSize = 20;
};
singleton GuiControlProfile (LogicMechanicsAboutTextProfile18)
{
   fontColor = "0 0 0";
   fontSize = 18;
};

singleton GuiControlProfile (LogicMechanicsTreeProfile : ToolsGuiTreeViewProfile)
{
    autoSizeHeight    = false;
    fontType = "Arial";
    fontSize = 16;
};

singleton GuiControlProfile (LogicMechanicsTextBoldCenterProfile)
{
   fontType = "Arial Bold";
   fontColor = "0 0 0";
   justify = "center";
};

singleton GuiControlProfile (LogicMechanicsTextBoldLeftProfile)
{
   fontType = "Arial Bold";
   fontColor = "0 0 0";
};

singleton GuiControlProfile( LogicMechanicsProgressProfile )
{
   opaque = false;
   fillColor = "255 0 0 200";
   border = true;
   borderColor   = "0 0 0 200";
   justify = "center";
   fontSize = "14";
};