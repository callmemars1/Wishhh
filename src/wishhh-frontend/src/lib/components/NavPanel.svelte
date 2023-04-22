<script lang='ts'>
	import { fly } from 'svelte/transition';

	import Logo from './Logo.svelte';
	import Menu from './Menu.svelte';
	import TextButton from './TextButton.svelte';
	import Footer from './Footer.svelte';

	export let hidden = false;
	export let open = false;

	const close = () => (open = false);
</script>

{#if open}
	<nav transition:fly={{ duration: 500, x: 700 }}>
		<header>
			<a href='/' on:click={close}>
				<Logo />
			</a>
			<TextButton text='x' on:click={close} />
		</header>
		<div class='main'>
			<Menu on:click={close} horizontal={false}>
				<slot />
			</Menu>
		</div>
		<div class='footer'>
			<Footer />
		</div>
	</nav>
{/if}

<style lang='less'>
  @import "../themes/default";
	
  nav {
    position: fixed;
    z-index: 99;
		.stickToTopRight();

    background: @accentBackgroundColor;
    color: @accentForegroundColor;
    font: @font;
    box-shadow: -0.25rem 0 2rem @accentColor;

    width: 100%;
    max-width: 500px;
    height: 100%;
		
    display: flex;
    flex-direction: column;
		align-items: center;
    gap: 20px;
		
    overflow-y: auto;
    overflow-x: hidden;
    .hideScrollBar();
  }

  header {
    display: flex;
    justify-content: space-around;
    align-items: center;
		min-height: 60px;
		width: 100%;
  }
	
	.main {
		width: 60%;
	}

  .footer {
    margin-top: auto;
		width: 80%;
  }

	.stickToTopRight() {
    top: 0;
    right: 0;
    bottom: 0;
  }

	.hideScrollBar() {
    -ms-overflow-style: none;
    scrollbar-width: none;

    &::-webkit-scrollbar {
      display: none;
    }
  }
</style>