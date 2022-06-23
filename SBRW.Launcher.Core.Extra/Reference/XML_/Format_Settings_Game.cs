using System;

namespace SBRW.Launcher.Core.Extra.Reference.XML_
{
    /// <summary>
    /// XML Format for Game Settings
    /// </summary>
    public class Format_Settings_Game
    {
        /* Language */
        /// <summary>
        /// Game Language
        /// </summary>
        /// <remarks>Affects Game and Chat Language</remarks>
        public string Language { get; set; } = "EN";
        /* Audio */
        /// <summary>
        /// Audio Quality Mode
        /// </summary>
        /// <remarks>
        /// <code>
        /// "1" - Stereo
        /// "2" - Surround
        /// </code>
        /// </remarks>
        public string AudioMode { get; set; } = "1";
        /// <summary>
        /// Main Game Volume
        /// </summary>
        /// <remarks><code>Must be within the range of 0-100</code></remarks>
        public string MasterAudio { get; set; } = "100";
        /// <summary>
        /// Special Sound Effects Volume
        /// </summary>
        /// <remarks><code>Must be within the range of 0-100</code></remarks>
        public string SFXAudio { get; set; } = "52";
        /// <summary>
        /// Car Sound Audio Volume
        /// </summary>
        /// <remarks><code>Must be within the range of 0-100</code></remarks>
        public string CarAudio { get; set; } = "52";
        /// <summary>
        /// Cop Speech Audio Volume
        /// </summary>
        /// <remarks><code>Must be within the range of 0-100</code></remarks>
        public string SpeechAudio { get; set; } = "52";
        /// <summary>
        /// In-Event Music Audio Volume
        /// </summary>
        /// <remarks><code>Must be within the range of 0-100</code></remarks>
        public string MusicAudio { get; set; } = "52";
        /// <summary>
        /// Freeroam Music Audio Volume
        /// </summary>
        /// <remarks><code>Must be within the range of 0-100</code></remarks>
        public string FreeroamAudio { get; set; } = "52";
        /* Gameplay */
        /// <summary>
        /// Camera Mode
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Bumper
        /// "1" - Hood
        /// "2" - Near
        /// "3" - Far
        /// </code>
        /// </remarks>
        public string Camera { get; set; } = "2";
        /// <summary>
        /// Transmission Mode
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Automatic
        /// "1" - Manual
        /// </code>
        /// </remarks>
        public string Transmission { get; set; } = "0";
        /// <summary>
        /// Visual Damage
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string Damage { get; set; } = "1";
        /// <summary>
        /// <i>No Details</i>
        /// </summary>
        public string Moments { get; set; } = "1";
        /// <summary>
        /// Speed Units
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Km/h
        /// "1" - Mp/h
        /// </code>
        /// </remarks>
        public string SpeedUnits { get; set; } = "1";
        /* Physics */
        /// <summary>
        /// Camera Mode
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Bumper
        /// "1" - Hood
        /// "2" - Near
        /// "3" - Far
        /// </code>
        /// <i>Should have the Same Value as ' Camera '</i>
        /// </remarks>
        public string CameraPOV { get; set; } = "2";
        /// <summary>
        /// Transmission Mode for Drag Races
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Automatic
        /// "1" - Manual
        /// </code>
        /// <i>Should have the Same Value as ' Transmission '</i>
        /// </remarks>
        public string TransmissionType { get; set; } = "1";
        /* VideoConfig */
        /// <summary>
        /// Audio Quality Mode
        /// </summary>
        /// <remarks>
        /// <code>
        /// "1" - Stereo
        /// "2" - Surround
        /// </code>
        /// <i>Should have the Same Value as ' AudioMode '</i>
        /// </remarks>
        public string AudioM { get; set; } = "1";
        /// <summary>
        /// Audio Quality Mode
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - High (Requires Maximum Settings)
        /// "1" - Low
        /// </code>
        /// </remarks>
        public string AudioQuality { get; set; } = "1";
        /// <summary>
        /// Game Brightness - <b><i>Full Screen Only</i></b>
        /// </summary>
        /// <remarks>
        /// <code>Must be within the range of 0-100</code>
        /// </remarks>
        public string Brightness { get; set; } = "0";
        /// <summary>
        /// Windows Aero
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Disable
        /// "1" - Enable
        /// </code>
        /// </remarks>
        public string EnableAero { get; set; } = "0";
        /// <summary>
        /// Force Check Game Quality Settings
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - No Check
        /// "1" - Force Check
        /// </code>
        /// </remarks>
        public string FirstTime { get; set; } = "0";
        /// <summary>
        /// Force Lower End Shader Model Requirements
        /// </summary>
        /// <remarks>
        /// <b><i>Only For Ancient GPUs</i></b>
        /// <code>
        /// "false" - Disable
        /// "true" - Enable
        /// </code>
        /// </remarks>
        public string ForcesM1x { get; set; } = "false";
        /// <summary>
        /// Graphic Settings (Global)
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Minimum
        /// "1" - Low
        /// "2" - Medium
        /// "3" - High
        /// "4" - Maximum
        /// "5" - Custom
        /// </code>
        /// </remarks>
        public string PerformanceLevel { get; set; } = "2";
        /// <summary>
        /// Frame POV
        /// </summary>
        /// <remarks>
        /// <code>Must be within the range of 0-100 (Down to Thousandths of a Decimal Point)</code>
        /// </remarks>
        public string PixelAspectRatioOverride { get; set; } = "2";
        /// <summary>
        /// Window Resolution: Height
        /// </summary>
        /// <remarks>
        /// <i>Resolution is based on Pixels</i>
        /// </remarks>
        public string ScreenHeight { get; set; } = "600";
        /// <summary>
        /// Window Resolution: Width
        /// </summary>
        /// <remarks>
        /// <i>Resolution is based on Pixels</i>
        /// </remarks>
        public string ScreenWidth { get; set; } = "800";
        /// <summary>
        /// Game Window
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Fullscreen
        /// "1" - Windowed
        /// </code>
        /// </remarks>
        public string ScreenWindowed { get; set; } = "0";
        /// <summary>
        /// VSync
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// <i>Set to <b>"1" - On</b> For Better handling by your Graphics Driver, if you want over 60fps</i>
        /// </remarks>
        public string VSyncOn { get; set; } = "0";
        /* VideoConfig Addons */
        /// <summary>
        /// <i>No Details</i>
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Bilinear
        /// "1" - Trilinear
        /// "2" - Anisotropic
        /// </code>
        /// </remarks>
        public string BaseTextureFilter { get; set; } = "0";
        /// <summary>
        /// Level of Detail: Render Distance
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string BaseTextureLODBias { get; set; } = "0";
        /// <summary>
        /// Anisotropic Filtering
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "2" - 2x
        /// "4" - 4x
        /// "8" - 8x
        /// "16" - 16x
        /// </code>
        /// </remarks>
        public string BaseTextureMaxAni { get; set; } = "0";
        /// <summary>
        /// Reflections Detail Level
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Minimum
        /// "1" - Low
        /// "2" - Medium
        /// "3" - High
        /// "4" - Maximum
        /// </code>
        /// </remarks>
        public string CarEnvironmentMapEnable { get; set; } = "0";
        /// <summary>
        /// Level of Detail: Cars
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off/Minimum
        /// "1" - On/Maximum
        /// </code>
        /// </remarks>
        public string CarLODLevel { get; set; } = "0";
        /// <summary>
        /// Antialiasing
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "2" - 2x
        /// "4" - 4x
        /// </code>
        /// </remarks>
        public string FSAALevel { get; set; } = "0";
        /// <summary>
        /// World Detail
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Minimum
        /// "1" - Low
        /// "2" - Medium
        /// "3" - High
        /// "4" - Maximum
        /// </code>
        /// </remarks>
        public string GlobalDetailLevel { get; set; } = "0";
        /// <summary>
        /// Skid Marks on Pavement
        /// </summary>
        /// <remarks>
        /// <i>The Amount and Persistence of Skid Marks</i>
        /// <code>
        /// "0" - 0
        /// "1" - 1
        /// "2" - 2
        /// </code>
        /// </remarks>
        public string MaxSkidMarks { get; set; } = "0";
        /// <summary>
        /// Motion Blur
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string MotionBlurEnable { get; set; } = "0";
        /// <summary>
        /// Over Bright
        /// </summary>
        /// <remarks>
        /// <i>Affects Performance When On</i>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string OverBrightEnable { get; set; } = "0";
        /// <summary>
        /// Particles
        /// </summary>
        /// <remarks>
        /// <i>Affects PowerUp(s), Smoke, and Fire</i>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string ParticleSystemEnable { get; set; } = "0";
        /// <summary>
        /// Post Processing
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string PostProcessingEnable { get; set; } = "0";
        /// <summary>
        /// Rain
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string RainEnable { get; set; } = "0";
        /// <summary>
        /// Road Reflections
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Minimum
        /// "1" - Medium
        /// "2" - Maximum
        /// </code>
        /// </remarks>
        public string RoadReflectionEnable { get; set; } = "0";
        /// <summary>
        /// Road Texture Filtering
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Minimum
        /// "1" - Medium
        /// "2" - Maximum
        /// </code>
        /// </remarks>
        public string RoadTextureFilter { get; set; } = "0";
        /// <summary>
        /// Road Render Distance
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string RoadTextureLODBias { get; set; } = "0";
        /// <summary>
        /// Road Texture Antialiasing
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "2" - 2x
        /// "4" - 4x
        /// </code>
        /// </remarks>
        public string RoadTextureMaxAni { get; set; } = "0";
        /// <summary>
        /// Surface Materials Quality
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Minimum
        /// "1" - Low
        /// "2" - Medium
        /// "4" - High
        /// </code>
        /// </remarks>
        public string ShaderDetail { get; set; } = "0";
        /// <summary>
        /// Shadows Quality
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Minimum
        /// "1" - Low
        /// "2" - Medium
        /// </code>
        /// </remarks>
        public string ShadowDetail { get; set; } = "0";
        /// <summary>
        /// VRAM Allocation
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Auto Detect
        /// Otherwise Set Max Allocation for VRAM
        /// </code>
        /// </remarks>
        public string Size { get; set; } = "0";
        /// <summary>
        /// Glitch Effect
        /// </summary>
        /// <remarks>
        /// <i>For Safehouse and Crash Wireframe Effect</i>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string VisualTreatment { get; set; } = "0";
        /// <summary>
        /// Water Simulation
        /// </summary>
        /// <remarks>
        /// <code>
        /// "0" - Off
        /// "1" - On
        /// </code>
        /// </remarks>
        public string WaterSimEnable { get; set; } = "0";
    }
}
