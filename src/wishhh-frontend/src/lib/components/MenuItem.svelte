<script lang='ts'>
	export let targetUrl: string = '#';
	export let label: string = '#';
</script>

<li class='menu-item' on:click>
	<a href='{targetUrl}'>
		<slot>{label}</slot>
	</a>
</li>

<style lang='less'>
	@import "../themes/default";
	
  .menu-item {
    list-style-type: none;
    justify-content: inherit;
  }

  a {
    display: flex;
    justify-content: center;
    align-items: center;
		

    white-space: nowrap;
    padding: 0.25em;
    border-radius: 0.5em;
  }

  a:hover {
    background: fade(@accentColor, 80%);
		color: @accentForegroundColor;
    transition: background-color 0.25s;
  }
</style>