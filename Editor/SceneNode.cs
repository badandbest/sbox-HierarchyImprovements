namespace Editor;

partial class SceneNode : GameObjectNode
{
	public SceneNode( Scene scene ) : base( scene )
	{

	}

	public override void OnPaint( VirtualWidget item )
	{
		var isEven = item.Row % 2 == 0;
		var fullSpanRect = item.Rect;
		fullSpanRect.Left = 0;
		fullSpanRect.Right = TreeView.Width;

		if ( item.Selected )
		{
			Paint.ClearPen();
			Paint.SetBrush( Theme.Blue.WithAlpha( 0.4f ) );
			Paint.DrawRect( fullSpanRect );

			Paint.SetPen( Theme.TextControl );
		}
		else if ( isEven )
		{
			Paint.ClearPen();
			Paint.SetBrush( Theme.SurfaceLightBackground.WithAlpha( 0.1f ) );
			Paint.DrawRect( fullSpanRect );
		}

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

