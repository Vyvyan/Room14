// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.7205882,fgcg:0.9537525,fgcb:1,fgca:1,fgde:0,fgrn:263.6,fgrf:2165.5,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:7728,x:33179,y:32729,varname:node_7728,prsc:2|emission-464-OUT;n:type:ShaderForge.SFN_NormalVector,id:7747,x:32091,y:32881,prsc:2,pt:False;n:type:ShaderForge.SFN_Transform,id:5247,x:32268,y:32902,varname:node_5247,prsc:2,tffrom:0,tfto:3|IN-7747-OUT;n:type:ShaderForge.SFN_RemapRange,id:7383,x:32377,y:33104,varname:node_7383,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5247-XYZ;n:type:ShaderForge.SFN_ComponentMask,id:4130,x:32467,y:32888,varname:node_4130,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7383-OUT;n:type:ShaderForge.SFN_Tex2d,id:5629,x:32486,y:32702,ptovrint:False,ptlb:node_5629,ptin:_node_5629,varname:node_5629,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-4130-OUT;n:type:ShaderForge.SFN_Multiply,id:464,x:32784,y:32862,varname:node_464,prsc:2|A-5629-RGB,B-7523-RGB;n:type:ShaderForge.SFN_Color,id:7523,x:32675,y:33095,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7523,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;proporder:5629-7523;pass:END;sub:END;*/

Shader "Unlit/MatCAp" {
    Properties {
        _node_5629 ("node_5629", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _node_5629; uniform float4 _node_5629_ST;
            uniform float4 _Color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float3 normalDir : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float2 node_4130 = (mul( UNITY_MATRIX_V, float4(i.normalDir,0) ).xyz.rgb*0.5+0.5).rg;
                float4 _node_5629_var = tex2D(_node_5629,TRANSFORM_TEX(node_4130, _node_5629));
                float3 emissive = (_node_5629_var.rgb*_Color.rgb);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
