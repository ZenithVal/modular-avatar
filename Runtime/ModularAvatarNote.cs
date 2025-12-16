using JetBrains.Annotations;
using UnityEngine;

namespace nadena.dev.modular_avatar.core
{
	[AddComponentMenu("Modular Avatar/MA Note")]
	[HelpURL("https://modular-avatar.nadena.dev/docs/reference/note?lang=auto")]
	public class ModularAvatarNote : AvatarTagComponent
	{
		[SerializeField][TextArea(5,20)] internal string m_note = "";
		[PublicAPI]
		public string Note
		{
			get => m_note;
			set => m_note = value;
		}
	}
}