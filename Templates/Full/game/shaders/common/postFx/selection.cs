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

singleton GFXStateBlockData( PFX_DefaultSelectionStateBlock : PFX_DefaultStateBlock)
{
zDefined = true;
zEnable = false;
zWriteEnable = false;
samplersDefined = true;
samplerStates[0] = SamplerClampLinear;
//samplerStates[1] = SamplerClampLinear;
//samplerStates[1] = SamplerWrapPoint;
};
singleton ShaderData( PFX_SelectionShader )
{
DXVertexShaderFile = "shaders/common/postFx/postFxV.hlsl";
DXPixelShaderFile = "shaders/common/postFx/selectionShaderP.hlsl";
samplerNames[0] = "$inputTex";
pixVersion = 3.0;
};
singleton PostEffect( SelectionPostFX )
{
renderTime = "PFXAfterDiffuse";
shader = PFX_SelectionShader;
stateBlock = PFX_DefaultSelectionStateBlock;
texture[0] = "#selection";
texture[1] = "$backBuffer";
target = "$backBuffer";
isEnabled = true;
};
/// Just here for debug visualization of the
/// SSAO mask texture used during lighting.
singleton PostEffect( SelectionVizPostFx )
{
allowReflectPass = false;
shader = PFX_PassthruShader;
stateBlock = PFX_DefaultStateBlock;
texture[0] = "#selection";
target = "$backbuffer";
};