using SBRW.Launcher.Core.Cache;
using SBRW.Launcher.Core.Downloader.LZMA_;
using SBRW.Launcher.Core.Extension.Logging_;
using SBRW.Launcher.Core.Extension.String_;
using SBRW.Launcher.Core.Extra.Reference.XML_;
using System;
using System.IO;
using System.Xml;

namespace SBRW.Launcher.Core.Extra.XML_
{
    /// <summary>
    /// 
    /// </summary>
    public class XML_File
    {
        private static XmlDocument UserSettingsFile { get; set; } = new XmlDocument();
        /// <summary>
        /// Settings Data Format
        /// </summary>
        public static Format_Settings_Game XML_Settings_Data { get; set; } = new Format_Settings_Game();
        /// <summary>
        /// Loads and Reads the XML (Settings File)
        /// </summary>
        /// <param name="Read_Pointer">
        /// "0" - "Screen Resolution Only"<br></br>
        /// "1" - "Language Only"<br></br>
        /// "2" - "Full File"
        /// </param>
        /// <returns>
        /// <b>-1</b> - Error Encountered<br></br>
        /// <b>0</b> - File Not Found<br></br>
        /// <b>1</b> - Loaded Successfully
        /// </returns>
        public static int Read(int Read_Pointer)
        {
            if (File.Exists(XML_Location.RoamingAppData_Game_XML))
            {
                try
                {
                    UserSettingsFile.Load(XML_Location.RoamingAppData_Game_XML);

                    if (Read_Pointer == 0)
                    {
                        /* VideoConfig */
                        XML_Settings_Data.ScreenHeight = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/screenheight", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/screenheight", null) : "600";
                        XML_Settings_Data.ScreenWidth = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/screenwidth", null))) ?
                                                            NodeReader(1, "Settings/VideoConfig/screenwidth", null) : "800";
                        XML_Settings_Data.ScreenWindowed = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/screenwindowed", null))) ?
                                                               NodeReader(1, "Settings/VideoConfig/screenwindowed", null) : "0";
                    }
                    else if (Read_Pointer == 1)
                    {
                        /* Language */
                        XML_Settings_Data.Language = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/UI/Language", null))) ?
                                                         NodeReader(1, "Settings/UI/Language", null) : Download_LZMA_Support.SpeechFiles().ToUpper();
                    }
                    else if (Read_Pointer == 2)
                    {
                        /* Audio */
                        XML_Settings_Data.AudioMode = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Audio/AudioOptions", "AudioMode"))) ?
                                                          NodeReader(0, "Settings/UI/Audio/AudioOptions", "AudioMode") : "0";
                        XML_Settings_Data.SFXAudio = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Audio/AudioOptions", "SFXVol"))) ?
                                                         NodeReader(0, "Settings/UI/Audio/AudioOptions", "SFXVol") : "100";
                        XML_Settings_Data.MasterAudio = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Audio/AudioOptions", "MasterVol"))) ?
                                                            NodeReader(0, "Settings/UI/Audio/AudioOptions", "MasterVol") : "100";
                        XML_Settings_Data.CarAudio = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Audio/AudioOptions", "CarVol"))) ?
                                                         NodeReader(0, "Settings/UI/Audio/AudioOptions", "CarVol") : "100";
                        XML_Settings_Data.SpeechAudio = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Audio/AudioOptions", "SpeechVol"))) ?
                                                            NodeReader(0, "Settings/UI/Audio/AudioOptions", "SpeechVol") : "100";
                        XML_Settings_Data.MusicAudio = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Audio/AudioOptions", "GameMusicVol"))) ?
                                                           NodeReader(0, "Settings/UI/Audio/AudioOptions", "GameMusicVol") : "100";
                        XML_Settings_Data.FreeroamAudio = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Audio/AudioOptions", "FEMusicVol"))) ?
                                                              NodeReader(0, "Settings/UI/Audio/AudioOptions", "FEMusicVol") : "100";
                        /* Gameplay */
                        XML_Settings_Data.Camera = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "camera"))) ?
                                                       NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "camera") : "2";
                        XML_Settings_Data.Transmission = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "transmission"))) ?
                                                             NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "transmission") : "2";
                        XML_Settings_Data.Damage = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "damage"))) ?
                                                       NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "damage") : "1";
                        XML_Settings_Data.Moments = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "moments"))) ?
                                                       NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "moments") : "1";
                        XML_Settings_Data.SpeedUnits = (!string.IsNullOrWhiteSpace(NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "speedUnits"))) ?
                                                           NodeReader(0, "Settings/UI/Gameplay/GamePlayOptions", "speedUnits") : "1";
                        /* Physics */
                        XML_Settings_Data.CameraPOV = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/Physics/CameraPOV", null))) ?
                                                          NodeReader(1, "Settings/Physics/CameraPOV", null) : "2";
                        XML_Settings_Data.TransmissionType = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/Physics/TransmissionType", null))) ?
                                                                 NodeReader(1, "Settings/Physics/TransmissionType", null) : "1";
                        /* VideoConfig */
                        XML_Settings_Data.AudioM = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/audiomode", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/audiomode", null) : "0";
                        XML_Settings_Data.AudioQuality = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/audioquality", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/audioquality", null) : "0";
                        XML_Settings_Data.Brightness = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/brightness", null))) ?
                                                           NodeReader(1, "Settings/VideoConfig/brightness", null) : "100";
                        XML_Settings_Data.EnableAero = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/enableaero", null))) ?
                                                           NodeReader(1, "Settings/VideoConfig/enableaero", null) : "0";
                        XML_Settings_Data.FirstTime = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/firsttime", null))) ?
                                                          NodeReader(1, "Settings/VideoConfig/firsttime", null) : "0";
                        XML_Settings_Data.ForcesM1x = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/forcesm1x", null))) ?
                                                          NodeReader(1, "Settings/VideoConfig/forcesm1x", null) : "False";
                        XML_Settings_Data.PixelAspectRatioOverride = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/pixelaspectratiooverride", null))) ?
                                                                         NodeReader(1, "Settings/VideoConfig/pixelaspectratiooverride", null) : "2";
                        XML_Settings_Data.PerformanceLevel = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/performancelevel", null))) ?
                                                                 NodeReader(1, "Settings/VideoConfig/performancelevel", null) : "2";
                        XML_Settings_Data.ScreenHeight = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/screenheight", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/screenheight", null) : "600";
                        XML_Settings_Data.ScreenWidth = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/screenwidth", null))) ?
                                                            NodeReader(1, "Settings/VideoConfig/screenwidth", null) : "800";
                        XML_Settings_Data.ScreenWindowed = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/screenwindowed", null))) ?
                                                               NodeReader(1, "Settings/VideoConfig/screenwindowed", null) : "0";
                        XML_Settings_Data.VSyncOn = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/vsyncon", null))) ?
                                                        NodeReader(1, "Settings/VideoConfig/vsyncon", null) : "0";
                        /* VideoConfig Addons */
                        XML_Settings_Data.BaseTextureFilter = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/basetexturefilter", null))) ?
                                                                  NodeReader(1, "Settings/VideoConfig/basetexturefilter", null) : "0";
                        XML_Settings_Data.BaseTextureLODBias = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/basetexturelodbias", null))) ?
                                                                   NodeReader(1, "Settings/VideoConfig/basetexturelodbias", null) : "0";
                        XML_Settings_Data.BaseTextureMaxAni = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/basetexturemaxani", null))) ?
                                                                  NodeReader(1, "Settings/VideoConfig/basetexturemaxani", null) : "0";
                        XML_Settings_Data.CarEnvironmentMapEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/carenvironmentmapenable", null))) ?
                                                                        NodeReader(1, "Settings/VideoConfig/carenvironmentmapenable", null) : "0";
                        XML_Settings_Data.CarLODLevel = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/carlodlevel", null))) ?
                                                            NodeReader(1, "Settings/VideoConfig/carlodlevel", null) : "0";
                        XML_Settings_Data.FSAALevel = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/fsaalevel", null))) ?
                                                          NodeReader(1, "Settings/VideoConfig/fsaalevel", null) : "0";
                        XML_Settings_Data.GlobalDetailLevel = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/globaldetaillevel", null))) ?
                                                                  NodeReader(1, "Settings/VideoConfig/globaldetaillevel", null) : "0";
                        XML_Settings_Data.MaxSkidMarks = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/maxskidmarks", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/maxskidmarks", null) : "0";
                        XML_Settings_Data.MotionBlurEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/motionblurenable", null))) ?
                                                                 NodeReader(1, "Settings/VideoConfig/motionblurenable", null) : "0";
                        XML_Settings_Data.OverBrightEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/overbrightenable", null))) ?
                                                                 NodeReader(1, "Settings/VideoConfig/overbrightenable", null) : "0";
                        XML_Settings_Data.ParticleSystemEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/particlesystemenable", null))) ?
                                                                     NodeReader(1, "Settings/VideoConfig/particlesystemenable", null) : "0";
                        XML_Settings_Data.PostProcessingEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/postprocessingenable", null))) ?
                                                                     NodeReader(1, "Settings/VideoConfig/postprocessingenable", null) : "0";
                        XML_Settings_Data.RainEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/rainenable", null))) ?
                                                           NodeReader(1, "Settings/VideoConfig/rainenable", null) : "0";
                        XML_Settings_Data.RoadReflectionEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/roadreflectionenable", null))) ?
                                                                     NodeReader(1, "Settings/VideoConfig/roadreflectionenable", null) : "0";
                        XML_Settings_Data.RoadTextureFilter = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/roadtexturefilter", null))) ?
                                                                  NodeReader(1, "Settings/VideoConfig/roadtexturefilter", null) : "0";
                        XML_Settings_Data.RoadTextureLODBias = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/roadtexturelodbias", null))) ?
                                                                   NodeReader(1, "Settings/VideoConfig/roadtexturelodbias", null) : "0";
                        XML_Settings_Data.RoadTextureMaxAni = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/roadtexturemaxani", null))) ?
                                                                  NodeReader(1, "Settings/VideoConfig/roadtexturemaxani", null) : "0";
                        XML_Settings_Data.ShaderDetail = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/shaderdetail", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/shaderdetail", null) : "0";
                        XML_Settings_Data.ShadowDetail = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/shadowdetail", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/shadowdetail", null) : "0";
                        XML_Settings_Data.Size = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/size", null))) ?
                                                             NodeReader(1, "Settings/VideoConfig/size", null) : "0";
                        XML_Settings_Data.VisualTreatment = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/visualtreatment", null))) ?
                                                                NodeReader(1, "Settings/VideoConfig/visualtreatment", null) : "0";
                        XML_Settings_Data.WaterSimEnable = (!string.IsNullOrWhiteSpace(NodeReader(1, "Settings/VideoConfig/watersimenable", null))) ?
                                                               NodeReader(1, "Settings/VideoConfig/watersimenable", null) : "0";

                        return 1;
                    }
                    else
                    {
                        Log.Warning("USX File: Unknown File Read Type -> " + Read_Pointer);
                    }
                }
                catch (Exception Error)
                {
                    Log_Detail.OpenLog("USX File", string.Empty, Error, string.Empty, true);
                }

                return -1;
            }
            else
            {
                Log.Error("USX File: No 'UserSettings.xml' found!");
                return 0;
            }
        }
        /// <summary>
        /// Saves the Current Values of the XML (Settings File)
        /// </summary>
        /// <param name="Read_Pointer">
        /// "0" - "Screen Resolution Only"<br></br>
        /// "1" - "Language Only"<br></br>
        /// "2" - "Full File"
        /// </param>
        /// <returns>
        /// <b>-1</b> - Error Encountered<br></br>
        /// <b>0</b> - File Is Read-Only<br></br>
        /// <b>1</b> - Saved Successfully
        /// </returns>
        public static int Save(int Read_Pointer)
        {
            try
            {
                if (Read_Pointer == 0)
                {
                    /* VideoConfig */
                    NodeUpdater(1, "Settings/VideoConfig", "screenheight", "Type", "int", XML_Settings_Data.ScreenHeight);
                    NodeUpdater(1, "Settings/VideoConfig", "screenwidth", "Type", "int", XML_Settings_Data.ScreenWidth);
                    NodeUpdater(1, "Settings/VideoConfig", "screenwindowed", "Type", "int", XML_Settings_Data.ScreenWindowed);
                }
                else if (Read_Pointer == 1)
                {
                    /* Language */
                    NodeUpdater(1, "Settings/PersistentValue/Chat", "DefaultChatGroup", "Type", "string", XML_Settings_Data.Language);
                    NodeUpdater(1, "Settings/UI", "Language", "Type", "string", XML_Settings_Data.Language);
                    /* Tracks */
                    NodeUpdater(1, "Settings/UI", "Tracks", "Type", "int", "1");
                }
                else if (Read_Pointer == 2)
                {
                    /* Audio */
                    NodeUpdater(0, "Settings/UI/Audio", "AudioOptions", "AudioMode", XML_Settings_Data.AudioMode, XML_Settings_Data.AudioMode);
                    NodeUpdater(0, "Settings/UI/Audio", "AudioOptions", "SFXVol", XML_Settings_Data.SFXAudio, XML_Settings_Data.SFXAudio);
                    NodeUpdater(0, "Settings/UI/Audio", "AudioOptions", "MasterVol", XML_Settings_Data.MasterAudio, XML_Settings_Data.MasterAudio);
                    NodeUpdater(0, "Settings/UI/Audio", "AudioOptions", "CarVol", XML_Settings_Data.CarAudio, XML_Settings_Data.CarAudio);
                    NodeUpdater(0, "Settings/UI/Audio", "AudioOptions", "SpeechVol", XML_Settings_Data.SpeechAudio, XML_Settings_Data.SpeechAudio);
                    NodeUpdater(0, "Settings/UI/Audio", "AudioOptions", "GameMusicVol", XML_Settings_Data.MusicAudio, XML_Settings_Data.MusicAudio);
                    NodeUpdater(0, "Settings/UI/Audio", "AudioOptions", "FEMusicVol", XML_Settings_Data.FreeroamAudio, XML_Settings_Data.FreeroamAudio);
                    /* Gameplay */
                    NodeUpdater(0, "Settings/UI/Gameplay", "GamePlayOptions", "camera", XML_Settings_Data.CameraPOV, XML_Settings_Data.CameraPOV);
                    NodeUpdater(0, "Settings/UI/Gameplay", "GamePlayOptions", "transmission", XML_Settings_Data.Transmission, XML_Settings_Data.Transmission);
                    NodeUpdater(0, "Settings/UI/Gameplay", "GamePlayOptions", "damage", XML_Settings_Data.Damage, XML_Settings_Data.Damage);
                    NodeUpdater(0, "Settings/UI/Gameplay", "GamePlayOptions", "moments", XML_Settings_Data.Moments, XML_Settings_Data.Moments);
                    NodeUpdater(0, "Settings/UI/Gameplay", "GamePlayOptions", "speedUnits", XML_Settings_Data.SpeedUnits, XML_Settings_Data.SpeedUnits);
                    /* Physics */
                    NodeUpdater(1, "Settings/Physics", "CameraPOV", "Type", "int", XML_Settings_Data.CameraPOV);
                    NodeUpdater(1, "Settings/Physics", "TransmissionType", "Type", "int", XML_Settings_Data.Transmission);
                    /* VideoConfig */
                    NodeUpdater(1, "Settings/VideoConfig", "audiomode", "Type", "int", XML_Settings_Data.AudioMode);
                    NodeUpdater(1, "Settings/VideoConfig", "audioquality", "Type", "int", XML_Settings_Data.AudioQuality);
                    NodeUpdater(1, "Settings/VideoConfig", "brightness", "Type", "int", XML_Settings_Data.Brightness);
                    NodeUpdater(1, "Settings/VideoConfig", "enableaero", "Type", "int", XML_Settings_Data.EnableAero);
                    NodeUpdater(1, "Settings/VideoConfig", "pixelaspectratiooverride", "Type", "int", XML_Settings_Data.PixelAspectRatioOverride);
                    NodeUpdater(1, "Settings/VideoConfig", "performancelevel", "Type", "int", XML_Settings_Data.PerformanceLevel);
                    NodeUpdater(1, "Settings/VideoConfig", "screenheight", "Type", "int", XML_Settings_Data.ScreenHeight);
                    NodeUpdater(1, "Settings/VideoConfig", "screenwidth", "Type", "int", XML_Settings_Data.ScreenWidth);
                    NodeUpdater(1, "Settings/VideoConfig", "screenwindowed", "Type", "int", XML_Settings_Data.ScreenWindowed);
                    NodeUpdater(1, "Settings/VideoConfig", "vsyncon", "Type", "int", XML_Settings_Data.VSyncOn);
                    /* VideoConfig Addons */
                    NodeUpdater(1, "Settings/VideoConfig", "basetexturefilter", "Type", "int", XML_Settings_Data.BaseTextureFilter);
                    NodeUpdater(1, "Settings/VideoConfig", "basetexturelodbias", "Type", "int", XML_Settings_Data.BaseTextureLODBias);
                    NodeUpdater(1, "Settings/VideoConfig", "basetexturemaxani", "Type", "int", XML_Settings_Data.BaseTextureMaxAni);
                    NodeUpdater(1, "Settings/VideoConfig", "carenvironmentmapenable", "Type", "int", XML_Settings_Data.CarEnvironmentMapEnable);
                    NodeUpdater(1, "Settings/VideoConfig", "carlodlevel", "Type", "int", XML_Settings_Data.CarLODLevel);
                    NodeUpdater(1, "Settings/VideoConfig", "fsaalevel", "Type", "int", XML_Settings_Data.FSAALevel);
                    NodeUpdater(1, "Settings/VideoConfig", "globaldetaillevel", "Type", "int", XML_Settings_Data.GlobalDetailLevel);
                    NodeUpdater(1, "Settings/VideoConfig", "maxskidmarks", "Type", "int", XML_Settings_Data.MaxSkidMarks);
                    NodeUpdater(1, "Settings/VideoConfig", "motionblurenable", "Type", "int", XML_Settings_Data.MotionBlurEnable);
                    NodeUpdater(1, "Settings/VideoConfig", "overbrightenable", "Type", "int", XML_Settings_Data.OverBrightEnable);
                    NodeUpdater(1, "Settings/VideoConfig", "particlesystemenable", "Type", "int", XML_Settings_Data.ParticleSystemEnable);
                    NodeUpdater(1, "Settings/VideoConfig", "postprocessingenable", "Type", "int", XML_Settings_Data.PostProcessingEnable);
                    NodeUpdater(1, "Settings/VideoConfig", "rainenable", "Type", "int", XML_Settings_Data.RainEnable);
                    NodeUpdater(1, "Settings/VideoConfig", "roadreflectionenable", "Type", "int", XML_Settings_Data.RoadReflectionEnable);
                    NodeUpdater(1, "Settings/VideoConfig", "roadtexturefilter", "Type", "int", XML_Settings_Data.RoadTextureFilter);
                    NodeUpdater(1, "Settings/VideoConfig", "roadtexturelodbias", "Type", "int", XML_Settings_Data.RoadTextureLODBias);
                    NodeUpdater(1, "Settings/VideoConfig", "roadtexturemaxani", "Type", "int", XML_Settings_Data.RoadTextureMaxAni);
                    NodeUpdater(1, "Settings/VideoConfig", "shaderdetail", "Type", "int", XML_Settings_Data.ShaderDetail);
                    NodeUpdater(1, "Settings/VideoConfig", "shadowdetail", "Type", "int", XML_Settings_Data.ShadowDetail);
                    NodeUpdater(1, "Settings/VideoConfig", "visualtreatment", "Type", "int", XML_Settings_Data.VisualTreatment);
                    NodeUpdater(1, "Settings/VideoConfig", "watersimenable", "Type", "int", XML_Settings_Data.WaterSimEnable);
                }
                else
                {
                    Log.Warning("USX File: Unknown File Read Pointer -> " + Read_Pointer);
                }

                if (new FileInfo(XML_Location.RoamingAppData_Game_XML).IsReadOnly != true)
                {
                    UserSettingsFile.Save(XML_Location.RoamingAppData_Game_XML);
                    return 1;
                }
                else
                {
                    Log.Error("USX File: UserSettings File is Read-Only. Settings Not Saved!");
                    return 0;
                }
            }
            catch (Exception Error)
            {
                Log_Detail.OpenLog("USX File", string.Empty, Error, string.Empty, true);
            }

            return -1;
        }
        /// <summary>
        /// Node Checker to Ensure it is Readable or Writeable
        /// </summary>
        /// <param name="Node_Type">
        /// "0" - Attributes<br></br>
        /// "1" - InnerText
        /// </param>
        /// <param name="NodeLocation"></param>
        /// <param name="AttributeName"></param>
        /// <returns>
        /// <b>True</b> If Node Exists, Else <b>False</b> if None was found or Encountered an Error
        /// </returns>
        public static bool NodeChecker(int Node_Type, string NodeLocation, string AttributeName)
        {
            try
            {
                if (Node_Type == 0)
                {
                    if (UserSettingsFile.SelectSingleNode(NodeLocation).Attributes[AttributeName].Value == null ||
                        UserSettingsFile.SelectSingleNode(NodeLocation).Attributes[AttributeName].Value != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (Node_Type == 1)
                {
                    if (UserSettingsFile.SelectSingleNode(NodeLocation).InnerText == null ||
                        UserSettingsFile.SelectSingleNode(NodeLocation).InnerText != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Updates the Node in the XML (Settings File)
        /// </summary>
        /// <param name="Node_Type">
        /// "0" - Attributes<br></br>
        /// "1" - InnerText
        /// </param>
        /// <param name="NodePath"></param>
        /// <param name="SingleNode"></param>
        /// <param name="AttributeName"></param>
        /// <param name="AttributeValue"></param>
        /// <param name="ValueComparison"></param>
        public static void NodeUpdater(int Node_Type, string NodePath, string SingleNode, string AttributeName, string AttributeValue, string ValueComparison)
        {
            string FullNodePath = Strings.Encode(NodePath + "/" + SingleNode);

            if (NodeChecker(Node_Type, FullNodePath, AttributeName) == false)
            {
                try
                {
                    XmlNode Root = UserSettingsFile.SelectSingleNode(Strings.Encode(NodePath));
                    XmlNode CustomNode = UserSettingsFile.CreateElement(Strings.Encode(SingleNode));
                    XmlAttribute CustomNodeAttribute = UserSettingsFile.CreateAttribute(Strings.Encode(AttributeName));
                    CustomNodeAttribute.Value = Strings.Encode(AttributeValue);
                    CustomNode.Attributes.Append(CustomNodeAttribute);
                    Root.AppendChild(CustomNode);
                    Log.Info("USX File: Created XML Node [Type: '" + Node_Type + "' NodePath: '" + NodePath + "' SingleNode: '" +
                                SingleNode + "' AttributeName: '" + AttributeName + "' AttributeValue: '" + AttributeValue + "']");
                }
                catch (System.Xml.XPath.XPathException Error)
                {
                    Log.Error("USX File: XML Node Is Null or Does not Exist [Type: '" + Node_Type + "' NodePath: '" + NodePath + "' SingleNode: '" +
                                SingleNode + "' AttributeName: '" + AttributeName + "' AttributeValue: '" + AttributeValue + "']" + Error.Message);
                    Log_Detail.OpenLog("USX File", string.Empty, Error, string.Empty, true);
                    return;
                }
                catch (Exception Error)
                {
                    Log.Error("USX File: Unable to Create XML Node [Type: '" + Node_Type + "' NodePath: '" + NodePath + "' SingleNode: '" +
                                SingleNode + "' AttributeName: '" + AttributeName + "' AttributeValue: '" + AttributeValue + "']" + Error.Message);
                    Log_Detail.OpenLog("USX File", string.Empty, Error, string.Empty, true);
                    return;
                }
            }

            if (Node_Type == 0)
            {
                if (Launcher_Value.Launcher_Insider_Dev || Launcher_Value.Launcher_Insider_Beta)
                {
                    Log.Debug("USX File: Comparing Values for '" + FullNodePath + "' CURRENT: '" + UserSettingsFile.SelectSingleNode(FullNodePath).Attributes[AttributeName].Value +
                              "' COMPARING NEW: '" + ValueComparison + "'");
                }

                if (UserSettingsFile.SelectSingleNode(FullNodePath).Attributes[Strings.Encode(AttributeName)].Value != Strings.Encode(ValueComparison))
                {
                    UserSettingsFile.SelectSingleNode(FullNodePath).Attributes[Strings.Encode(AttributeName)].Value = Strings.Encode(ValueComparison);
                }
            }
            else if (Node_Type == 1)
            {
                if (Launcher_Value.Launcher_Insider_Dev || Launcher_Value.Launcher_Insider_Beta)
                {
                    Log.Debug("USX File: Comparing Values for '" + FullNodePath + "' CURRENT: '" + UserSettingsFile.SelectSingleNode(FullNodePath).InnerText +
                              "' COMPARING NEW: '" + ValueComparison + "'");
                }

                if (UserSettingsFile.SelectSingleNode(FullNodePath).InnerText != Strings.Encode(ValueComparison))
                {
                    UserSettingsFile.SelectSingleNode(FullNodePath).InnerText = Strings.Encode(ValueComparison);
                }
            }
            else
            {
                Log.Error("USX File: Unknown 'Node_Type' Value (Provided)");
            }
        }
        /// <summary>
        /// Reads and Retrieves the Value from a Node
        /// </summary>
        /// <param name="Node_Type">
        /// "0" - Attributes<br></br>
        /// "1" - InnerText
        /// </param>
        /// <param name="Full_Node_Path">Node Path</param>
        /// <param name="Attribute_Name">Attribute Node Name</param>
        /// <returns>String Value if the Node Exists. Else, null will be provided</returns>
        public static string NodeReader(int Node_Type, string Full_Node_Path, string Attribute_Name)
        {
            try
            {
                if (Node_Type == 0)
                {
                    if (UserSettingsFile.SelectSingleNode(Full_Node_Path).Attributes[Attribute_Name].Value == null)
                    {
                        return null;
                    }
                    else
                    {
                        return UserSettingsFile.SelectSingleNode(Full_Node_Path).Attributes[Attribute_Name].Value;
                    }
                }
                else if (Node_Type == 1)
                {
                    if (UserSettingsFile.SelectSingleNode(Full_Node_Path).InnerText == null)
                    {
                        return null;
                    }
                    else
                    {
                        return UserSettingsFile.SelectSingleNode(Full_Node_Path).InnerText;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (System.Xml.XPath.XPathException Error)
            {
                Log.Warning("USX File: XML Node Is Null or Does not Exist [NodePath: '" + Full_Node_Path + "']" + Error.Message);
                return null;
            }
            catch (Exception Error)
            {
                Log.Error("USX File: Unable to Read XML Node [NodePath: '" + Full_Node_Path + "' AttributeName: '" + Attribute_Name + "']" + Error.Message);
                Log_Detail.OpenLog("USX File", string.Empty, Error, string.Empty, true);
                return null;
            }
        }
    }
}