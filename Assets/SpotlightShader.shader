Shader "Unlit/SpotlightShader"
{
    // Properties
    // {
    //     _MainTex ("Texture", 2D) = "white" {}
    // }
    // SubShader
    // {
    //     Tags { "RenderType"="Opaque" }
    //     LOD 100

    //     Pass
    //     {
    //         CGPROGRAM
    //         #pragma vertex vert
    //         #pragma fragment frag
    //         // make fog work
    //         #pragma multi_compile_fog

    //         #include "UnityCG.cginc"

    //         struct appdata
    //         {
    //             float4 vertex : POSITION;
    //             float2 uv : TEXCOORD0;
    //         };

    //         struct v2f
    //         {
    //             float2 uv : TEXCOORD0;
    //             UNITY_FOG_COORDS(1)
    //             float4 vertex : SV_POSITION;
    //         };

    //         sampler2D _MainTex;
    //         float4 _MainTex_ST;

    //         v2f vert (appdata v)
    //         {
    //             v2f o;
    //             o.vertex = UnityObjectToClipPos(v.vertex);
    //             o.uv = TRANSFORM_TEX(v.uv, _MainTex);
    //             UNITY_TRANSFER_FOG(o,o.vertex);
    //             return o;
    //         }

    //         fixed4 frag (v2f i) : SV_Target
    //         {
    //             // sample the texture
    //             fixed4 col = tex2D(_MainTex, i.uv);
    //             // apply fog
    //             UNITY_APPLY_FOG(i.fogCoord, col);
    //             return col;
    //         }
    //         ENDCG
    //     }
    // }
    Properties
    {
        _Color ("Overlay Color", Color) = (0,0,0,1)
        _SpotCenter ("Spotlight Center", Vector) = (0.5, 0.5, 0, 0)
        _Radius ("Radius", Float) = 0.2
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Overlay" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            fixed4 _Color;
            float4 _SpotCenter;
            float _Radius;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float dist = distance(i.uv, _SpotCenter.xy);
                float alpha = smoothstep(_Radius, _Radius * 0.8, dist);
                return fixed4(_Color.rgb, alpha * _Color.a);
            }
            ENDCG
        }
    }
}
