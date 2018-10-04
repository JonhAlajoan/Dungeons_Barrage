Shader "uShader 2/NewShader" { 
	Properties { 
		[Header (Textures and Bumpmaps)]_Texture("Texture", 2D) = "white" {}
		[Header (Colors)]_Color("Color", Color) = (0,1,0.6689656,1)
		[Header (Variables)]_Var("Var", float) = 2
	}
	SubShader {
		LOD 300
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}

		Fog {
			Mode Global
			Density 0
			Color (1, 1, 1, 1) 
			Range 0, 300
		}

		Stencil {
			Ref 0
			Comp Always
			Pass Keep
			Fail Keep
			ZFail Keep
		}

		Cull Off
		ZWrite  On
		ColorMask   RGBA

		CGPROGRAM 
		#pragma surface surf Standard addshadow fullforwardshadows 
		#pragma target 4.0
		#include "UnityCG.cginc"

		sampler2D _Texture;
		float4 _Color;
		float _Var;
		float3 _p0_pi0_nc1_o4;
		float3 _p0_pi0_nc4_o0;
		float3 _p0_pi0_nc5_o0;
		float _p0_pi0_nc6_o2;
		float _p0_pi0_nc14_o2;
		float _p0_pi0_nc15_o0;

		struct appdata{
			float4 vertex    : POSITION;  // The vertex position in model space.
			float3 normal    : NORMAL;    // The vertex normal in model space.
			float4 texcoord  : TEXCOORD0; // The first UV coordinate.
			float4 texcoord1 : TEXCOORD1; // The second UV coordinate.
			float4 texcoord2 : TEXCOORD2; // The third UV coordinate.
			float4 tangent   : TANGENT;   // The tangent vector in Model Space (used for normal mapping).
			float4 color     : COLOR;     // Per-vertex color.
		};

		struct Input{
			float2 texcoord : TEXCOORD0;
			float2 texcoord1 : TEXCOORD1;
			float2 uv_Texture;
			float3 viewDir;
			float3 worldRefl;
			float4 position;

			INTERNAL_DATA
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			_p0_pi0_nc1_o4 = tex2D(_Texture, IN.uv_Texture).rgb;
			_p0_pi0_nc4_o0 = IN.worldRefl;
			_p0_pi0_nc5_o0 = IN.viewDir;
			_p0_pi0_nc6_o2 = dot(_p0_pi0_nc5_o0, _p0_pi0_nc4_o0);
			_p0_pi0_nc15_o0 = _Var;
			_p0_pi0_nc14_o2 = pow(_p0_pi0_nc6_o2, _p0_pi0_nc15_o0);
			o.Emission = _p0_pi0_nc1_o4;
		}
		ENDCG

	}
	FallBack "Diffuse"
}
