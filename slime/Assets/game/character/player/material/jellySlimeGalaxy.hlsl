#ifndef jellySlime_HLSL
#define jellySlime_HLSL
#endif

float2 UVCenter(float2 uv,float range){
    float2 newUV=(uv-0.5)*(range)*2;
    return newUV;
}

float4 jelly_float(in float2 uv:TEXCOORD0){
    float d=length(UVCenter(uv,1));

    return float4(d,d,d,1);
}

float4 main(in float2 uv:TEXCOORD0):SV_Target{
    return jelly_float(uv);
}