// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Proxy/SkyboxStarsShader"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_TextureAlbedo("TextureAlbedo", 2D) = "white" {}
		_GradientAlbedo("GradientAlbedo", 2D) = "white" {}
		_TextureIntensity("TextureIntensity", Float) = 1
		_GradientIntensity("GradientIntensity", Float) = 1
		_TextureColor("TextureColor", Color) = (1,1,1,0)
		_GradientScroll("GradientScroll", Vector) = (1,1,0,0)
		_GradientTiling("GradientTiling", Vector) = (1,1,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull Front
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _GradientAlbedo;
		uniform float2 _GradientTiling;
		uniform float2 _GradientScroll;
		uniform float _GradientIntensity;
		uniform sampler2D _TextureAlbedo;
		uniform float4 _TextureAlbedo_ST;
		uniform float4 _TextureColor;
		uniform float _TextureIntensity;
		uniform float _Cutoff = 0.5;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv_TexCoord10 = i.uv_texcoord * _GradientTiling + ( _GradientScroll * _Time.y );
			float2 uv_TextureAlbedo = i.uv_texcoord * _TextureAlbedo_ST.xy + _TextureAlbedo_ST.zw;
			float4 tex2DNode1 = tex2D( _TextureAlbedo, uv_TextureAlbedo );
			o.Emission = ( ( tex2D( _GradientAlbedo, uv_TexCoord10 ) * _GradientIntensity ) * ( ( tex2DNode1 * _TextureColor ) * _TextureIntensity ) ).rgb;
			o.Alpha = 1;
			clip( tex2DNode1.a - _Cutoff );
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16600
116;503;1286;614;1572.026;760.777;1.6;True;True
Node;AmplifyShaderEditor.TimeNode;13;-1772.833,-501.0322;Float;False;0;5;FLOAT4;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.Vector2Node;14;-1758.239,-652.2369;Float;False;Property;_GradientScroll;GradientScroll;6;0;Create;True;0;0;False;0;1,1;0.05,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-1471.833,-564.0322;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.Vector2Node;15;-1491.392,-700.3522;Float;False;Property;_GradientTiling;GradientTiling;7;0;Create;True;0;0;False;0;1,1;1,1;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.ColorNode;5;-1245.861,-225.339;Float;False;Property;_TextureColor;TextureColor;5;0;Create;True;0;0;False;0;1,1,1,0;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;1;-1330.058,-438.7857;Float;True;Property;_TextureAlbedo;TextureAlbedo;1;0;Create;True;0;0;False;0;None;4440b2f117327694895b13106a4007da;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TextureCoordinatesNode;10;-1254.064,-668.5195;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-968.1584,-293.2874;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;3;-1191.207,-3.029596;Float;False;Property;_TextureIntensity;TextureIntensity;3;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-792.692,-395.0627;Float;False;Property;_GradientIntensity;GradientIntensity;4;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;7;-886.7316,-608.0344;Float;True;Property;_GradientAlbedo;GradientAlbedo;2;0;Create;True;0;0;False;0;None;2e084ef96e907134a92d8b356e82ef74;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;2;-738.5126,-160.6975;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-527.7928,-395.6429;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-319.8876,-244.874;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Proxy/SkyboxStarsShader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Front;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;False;0;True;TransparentCutout;;Transparent;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;12;0;14;0
WireConnection;12;1;13;2
WireConnection;10;0;15;0
WireConnection;10;1;12;0
WireConnection;4;0;1;0
WireConnection;4;1;5;0
WireConnection;7;1;10;0
WireConnection;2;0;4;0
WireConnection;2;1;3;0
WireConnection;18;0;7;0
WireConnection;18;1;6;0
WireConnection;17;0;18;0
WireConnection;17;1;2;0
WireConnection;0;2;17;0
WireConnection;0;10;1;4
ASEEND*/
//CHKSM=2B7DF7211F41751D871E8D3C41F87211B8C8C355