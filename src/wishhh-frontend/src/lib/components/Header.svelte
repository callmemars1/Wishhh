<script>
	import MenuItem from './MenuItem.svelte';
	import Menu from './Menu.svelte';
	import Logo from './Logo.svelte';
	import NavPanel from './NavPanel.svelte';
	import TextButton from './TextButton.svelte';

	let panelOpen = false;
</script>

<div class='header'>

	<div class='logo'>
		<a href='/'>
			<Logo />
		</a>
	</div>

	<nav class='only-desktop'>
		<Menu>
			<MenuItem label='cringe' />
			<MenuItem label='cringe' />
			<MenuItem label='cringe' />
		</Menu>
	</nav>

	<div class='only-mobile'>
		<TextButton text='&#9776;' on:click={() => panelOpen = true}/>
	</div>
</div>

<div class='nav-panel only-mobile'>
	<NavPanel bind:open={panelOpen}>
		<MenuItem label='cringe' />
		<MenuItem label='cringe' />
		<MenuItem label='cringe' />
	</NavPanel>
</div>

<style lang='less'>
  @import "../themes/default";

	.shadow() {
    -webkit-box-shadow: 0 8px 17px 2px @accentBackgroundColor;
    -moz-box-shadow: 0 8px 17px 2px @accentBackgroundColor;
    box-shadow: 0 8px 17px 2px @accentBackgroundColor;
	}
	
  .header {
    font: @monoFont;
    background: @accentBackgroundColor;
    color: @accentForegroundColor;
		.shadow();

    display: flex;
    min-height: 60px;

    justify-content: space-around;
    align-items: center;

    gap: 10%;
  }

  .only-mobile {
    display: none;
  }
	
  @media (max-width: 768px) {
    .only-desktop {
      display: none;
    }

    .only-mobile {
      display: flex;
    }

    .nav-panel {
      display: contents;
    }
  }
</style>