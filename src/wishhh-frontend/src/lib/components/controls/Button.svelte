<div class='btn' on:click>
	<slot />
</div>

<style lang='less'>
	@import "../../themes/default";
	
  .btn {
    border-radius: 5px;
		padding: 0.25em 0.5em;
		border: 2px solid @accentColor;
		display: flex;
		flex-direction: column;
		align-items: center;
		justify-content: center;
  }
	
	.btn:hover {
		background: @accentColor;
		color: @foregroundColor;
		cursor: pointer;
		user-select: none;
		transition: all 0.2s;
	}
</style>