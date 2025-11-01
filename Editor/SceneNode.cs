namespace Editor;

partial class SceneNode : GameObjectNode
{
	public SceneNode( Scene scene ) : base( scene )
	{

	}

	public override void OnPaint( VirtualWidget item )
	{
		var r = item.Rect;
		Paint.SetPen( Theme.TextControl.WithAlpha( 0.4f ) );

		r.Left += 4;
		Paint.DrawIcon( r, "perm_media", 14, TextFlag.LeftCenter );
		r.Left += 22;
		Paint.SetDefaultFont();
		Paint.DrawText( r, $"{Value.Name}", TextFlag.LeftCenter );
	}

	public override bool OnDragStart()
	{
		return false;
	}
}

