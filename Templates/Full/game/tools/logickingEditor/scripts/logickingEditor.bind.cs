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

new ActionMap(LogickingEditorMap);

LogickingEditorMap.bindCmd(keyboard, "n", " schedule(0.5, 0, selectTag); ", "");
LogickingEditorMap.bindCmd(keyboard, "numpadadd", " schedule(0.5, 0, selectTag); ", "");

LogickingEditorMap.bindCmd(keyboard, "enter", " if(LogickingEditor.currentObjects !$= \"\") LogickingEditor.showWindow(LogickingEditorFieldEditor); ", "");
LogickingEditorMap.bindCmd(keyboard, "numpadenter", " if(LogickingEditor.currentObjects !$= \"\") LogickingEditor.showWindow(LogickingEditorFieldEditor); ", "");

LogickingEditorMap.bindCmd(keyboard, "t", " LogickingEditor.toggleWindow(LogickingEditorTemplatesList); ", "");
LogickingEditorMap.bindCmd(keyboard, "numpadminus", " LogickingEditor.toggleWindow(LogickingEditorTemplatesList); ", "");

LogickingEditorMap.bindCmd(keyboard, "l", " LogickingEditorObjectsList.caller = LogickingEditor; LogickingEditorObjectsList.classNameFilter = \"\"; LogickingEditor.toggleWindow(LogickingEditorObjectsList); ", "");
LogickingEditorMap.bindCmd(keyboard, "numpadmult", " LogickingEditorObjectsList.caller = LogickingEditor; LogickingEditorObjectsList.classNameFilter = \"\"; LogickingEditor.toggleWindow(LogickingEditorObjectsList); ", "");

LogickingEditorMap.bindCmd(keyboard, "c", " LogickingEditor.castRay(); ", "");


LogickingEditorMap.bindCmd(keyboard, "up", " LogickingEditor.onKeyboardEvent(0, \"forward\"); ", " LogickingEditor.onKeyboardEvent(0, \"\"); ");
LogickingEditorMap.bindCmd(keyboard, "right", " LogickingEditor.onKeyboardEvent(1, \"right\"); ", " LogickingEditor.onKeyboardEvent(1, \"\"); ");
LogickingEditorMap.bindCmd(keyboard, "down", " LogickingEditor.onKeyboardEvent(2, \"backward\"); ", " LogickingEditor.onKeyboardEvent(2, \"\"); ");
LogickingEditorMap.bindCmd(keyboard, "left", " LogickingEditor.onKeyboardEvent(3, \"left\"); ", " LogickingEditor.onKeyboardEvent(3, \"\"); ");

LogickingEditorMap.bindCmd(keyboard, "pageup", " LogickingEditor.onKeyboardEvent(4, \"pageup\"); ", " LogickingEditor.onKeyboardEvent(4, \"\"); ");
LogickingEditorMap.bindCmd(keyboard, "pagedown", " LogickingEditor.onKeyboardEvent(5, \"pagedown\"); ", " LogickingEditor.onKeyboardEvent(5, \"\"); ");

LogickingEditorMap.bindCmd(keyboard, "space", " LogickingEditorFieldEditor.stopFly(); ", "");

