using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace nadena.dev.modular_avatar.core
{
	[AddComponentMenu("Modular Avatar/MA Note")]
	[HelpURL("https://modular-avatar.nadena.dev/docs/reference/note?lang=auto")]
	public class ModularAvatarNote : AvatarTagComponent
	{
		[SerializeField] internal string m_note = "This is a note.";
		[SerializeField] internal HelpBoxMessageType m_noteStyle = HelpBoxMessageType.None;
		
		[PublicAPI]
		public string Note
		{
			get => m_note;
			set => m_note = value;
		}

		public HelpBoxMessageType NoteStyle
		{
			get => m_noteStyle;
			set => m_noteStyle = value;
		}
	}
}