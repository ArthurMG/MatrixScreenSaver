using System.Collections.Generic;
using System.Globalization;

namespace MatrixScreensaver
{
    internal static class LocalizedStrings
    {
        private static readonly Dictionary<string, Dictionary<string, string>> _data = new Dictionary<string, Dictionary<string, string>>
        {
            ["en"] = new Dictionary<string, string>
            {
                [nameof(SettingsForm_Title)] = "Matrix Screensaver Settings",
                [nameof(GbSize_Text)] = "Character Size",
                [nameof(RbSizeSmall_Text)] = "Small",
                [nameof(RbSizeMedium_Text)] = "Medium",
                [nameof(RbSizeLarge_Text)] = "Large",
                [nameof(GbSpeed_Text)] = "Speed",
                [nameof(RbSpeedSlow_Text)] = "Slow",
                [nameof(RbSpeedMedium_Text)] = "Medium",
                [nameof(RbSpeedFast_Text)] = "Fast",
                [nameof(BtnOk_Text)] = "Save",
                [nameof(BtnCancel_Text)] = "Cancel",
                [nameof(GbColor_Text)] = "Color",
                [nameof(LblColor_Text)] = "Character:",
                [nameof(BtnSelectColor_Text)] = "Select...",
                [nameof(GbGlow_Text)] = "Glow",
                [nameof(LblGlowOffset_Text)] = "Offset:",
            },
            ["ru"] = new Dictionary<string, string>
            {
                [nameof(SettingsForm_Title)] = "Настройка Matrix Screensaver",
                [nameof(GbSize_Text)] = "Размер символов",
                [nameof(RbSizeSmall_Text)] = "Маленький",
                [nameof(RbSizeMedium_Text)] = "Средний",
                [nameof(RbSizeLarge_Text)] = "Большой",
                [nameof(GbSpeed_Text)] = "Скорость",
                [nameof(RbSpeedSlow_Text)] = "Медленная",
                [nameof(RbSpeedMedium_Text)] = "Средняя",
                [nameof(RbSpeedFast_Text)] = "Быстрая",
                [nameof(BtnOk_Text)] = "Сохранить",
                [nameof(BtnCancel_Text)] = "Отмена",
                [nameof(GbColor_Text)] = "Цвет",
                [nameof(LblColor_Text)] = "Символы:",
                [nameof(BtnSelectColor_Text)] = "Выбрать...",
                [nameof(GbGlow_Text)] = "Свечение",
                [nameof(LblGlowOffset_Text)] = "Смещение:",
            }
        };

        private static readonly Dictionary<string, string> _current;

        static LocalizedStrings()
        {
            var lang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            _current = _data.TryGetValue(lang, out var dict) ? dict : _data["en"];
        }

        public static string SettingsForm_Title => _current[nameof(SettingsForm_Title)];
        public static string GbSize_Text => _current[nameof(GbSize_Text)];
        public static string RbSizeSmall_Text => _current[nameof(RbSizeSmall_Text)];
        public static string RbSizeMedium_Text => _current[nameof(RbSizeMedium_Text)];
        public static string RbSizeLarge_Text => _current[nameof(RbSizeLarge_Text)];
        public static string GbSpeed_Text => _current[nameof(GbSpeed_Text)];
        public static string RbSpeedSlow_Text => _current[nameof(RbSpeedSlow_Text)];
        public static string RbSpeedMedium_Text => _current[nameof(RbSpeedMedium_Text)];
        public static string RbSpeedFast_Text => _current[nameof(RbSpeedFast_Text)];
        public static string BtnOk_Text => _current[nameof(BtnOk_Text)];
        public static string BtnCancel_Text => _current[nameof(BtnCancel_Text)];
        public static string GbColor_Text => _current[nameof(GbColor_Text)];
        public static string LblColor_Text => _current[nameof(LblColor_Text)];
        public static string BtnSelectColor_Text => _current[nameof(BtnSelectColor_Text)];
        public static string GbGlow_Text => _current[nameof(GbGlow_Text)];
        public static string LblGlowOffset_Text => _current[nameof(LblGlowOffset_Text)];
    }
}
