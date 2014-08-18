//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
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

#ifndef _TEXTARGETBIN_MGR_H_
#include "renderInstance/renderTexTargetBinManager.h"
#endif
class PostEffect;
class RenderSelectionMgr : public RenderTexTargetBinManager
{
typedef RenderTexTargetBinManager Parent;
public:
RenderSelectionMgr();
virtual ~RenderSelectionMgr();
/// Returns true if the selection post effect is
/// enabled and the selection buffer should be updated.
bool isSelectionEnabled();
/// Returns the glow post effect.
PostEffect* getSelectionEffect();
// RenderBinManager
virtual void addElement( RenderInst *inst );
virtual void render( SceneRenderState *state );
// ConsoleObject
DECLARE_CONOBJECT( RenderSelectionMgr );
protected:
class SelectionMaterialHook : public MatInstanceHook
{
public:
SelectionMaterialHook( BaseMatInstance *matInst );
virtual ~SelectionMaterialHook();
virtual BaseMatInstance *getMatInstance() { return mSelectionMatInst; }
virtual const MatInstanceHookType& getType() const { return Type; }
/// Our material hook type.
static const MatInstanceHookType Type;
protected:
static void _overrideFeatures( ProcessedMaterial *mat,
U32 stageNum,
MaterialFeatureData &fd,
const FeatureSet &features );
BaseMatInstance *mSelectionMatInst;
};
SimObjectPtr<PostEffect> mSelectionEffect;
};