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
// Selection by Konrad Kiss & smally

#include "postFx.hlsl"
#include "shadergen:/autogenConditioners.h"

float4 main( PFXVertToPix IN,
uniform sampler2D selectionBuffer :register(S0),
uniform sampler2D backBuffer : register(S1),
uniform float2 targetSize : register(C0) ) : COLOR0
{
float2 offsets[9] = {
float2( 0.0, 0.0),
float2(-1.0, -1.0),
float2( 0.0, -1.0),
float2( 1.0, -1.0),
float2( 1.0, 0.0),
float2( 1.0, 1.0),
float2( 0.0, 1.0),
float2(-1.0, 1.0),
float2(-1.0, 0.0),
};
float2 PixelSize = 1.0 / targetSize;
float avgval = 0;
for(int i = 0; i < 9; i++)
{
float2 uv = IN.uv0 + offsets[i] * PixelSize;
float4 cpix = float4( tex2D( selectionBuffer, uv ).rrr, 1.0 );
avgval += clamp(cpix.r*256, 0, 1);
}
avgval /= 9;
float vis = round(1.0-(abs(frac(avgval)-0.5)*2));
float4 bb = tex2D(backBuffer, IN.uv0);
float4 e = float4(vis, 0, 0, vis);
float4 ovr = float4(avgval, 0, 0, avgval);
ovr *= 0.4;
bb = lerp(bb, ovr, ovr.a);
e = lerp(bb, e, e.a);
return e;
} 