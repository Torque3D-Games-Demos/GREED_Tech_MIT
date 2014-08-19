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

function initializeLogickingEditor()
{
    exec("./scripts/init.cs");
    exec("./scripts/logickingEditor.bind.cs");
    
    exec("./scripts/templateUtilities.cs");
	exec("./scripts/controls.cs");
	exec("./gui/profiles.cs");
	exec("./gui/logickingEditor.ed.gui");
	exec("./gui/logickingEditorFieldEditor.ed.gui");
	exec("./gui/logickingEditorFieldInspector.ed.gui");
	exec("./gui/logickingEditorObjectsList.ed.gui");
	exec("./gui/logickingEditorTemplatesList.ed.gui");	
	exec("./scripts/logickingEditor.ed.cs");
	exec("./scripts/objectsList.ed.cs");
	exec("./scripts/fieldsEditor.cs");
	exec("./scripts/templatesList.cs");
	exec("./gui/about.ed.gui");
	exec("./gui/settings.ed.gui");
}