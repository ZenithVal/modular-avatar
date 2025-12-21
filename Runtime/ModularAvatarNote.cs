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
		
		[PublicAPI]
		public string Note
		{
			get => m_note;
			set => m_note = value;
		}
	}
}