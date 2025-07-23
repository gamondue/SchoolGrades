using SchoolGrades.BusinessObjects;

namespace TreeMpttBlazor.Extensions
{
    public static class TopicExtensions
    {
        // Dizionari statici per mantenere lo stato UI dei Topic
        private static readonly Dictionary<int, bool> _checkedStates = new();
        private static readonly Dictionary<int, bool> _highlightedStates = new();

        public static bool IsChecked(this Topic topic)
        {
            return topic.Id.HasValue && _checkedStates.TryGetValue(topic.Id.Value, out bool value) && value;
        }

        public static void SetChecked(this Topic topic, bool value)
        {
            if (topic.Id.HasValue)
            {
                _checkedStates[topic.Id.Value] = value;
            }
        }

        public static bool IsHighlighted(this Topic topic)
        {
            return topic.Id.HasValue && _highlightedStates.TryGetValue(topic.Id.Value, out bool value) && value;
        }

        public static void SetHighlighted(this Topic topic, bool value)
        {
            if (topic.Id.HasValue)
            {
                _highlightedStates[topic.Id.Value] = value;
            }
        }

        public static void ClearUIStates()
        {
            _checkedStates.Clear();
            _highlightedStates.Clear();
        }

        public static void ClearCheckedStates()
        {
            _checkedStates.Clear();
        }

        public static void ClearHighlightedStates()
        {
            _highlightedStates.Clear();
        }
    }
}