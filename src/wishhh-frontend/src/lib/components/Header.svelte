<script lang='ts'>
	import cat from '$lib/images/cat.jpg';
	import './Styles/Header.css';
	import Profile from './Profile.svelte';
	import { onMount } from 'svelte';

	let showText = true;
	let widthWrapper: HTMLElement;
	let checkBox: HTMLInputElement;
	let width: number;

	const adjustElementsAccordingToWindowSize = () => {
		if (innerWidth <= 400) {
			showText = false;
			width = widthWrapper.clientWidth * 0.8;
		}
		else if (innerWidth >= 400 && innerWidth < 1200) {
			showText = true;
			width = widthWrapper.clientWidth * 0.8
		}
		else if (innerWidth >= 1200) {
			checkBox.checked = false
			checkBox = checkBox
			showText = false;
			width = 40
		}
	};

	onMount(adjustElementsAccordingToWindowSize)
</script>

<svelte:window on:resize={adjustElementsAccordingToWindowSize} />

<nav>
	<a href='/wishlists' class='logo'>Wishhh</a>
	<div class='links'>
		<menu class='menu-items' bind:this={widthWrapper}>
			<li><a href='/wishlists'>Wishhh</a></li>
			<li><a href='/wishlists'>Мои желания</a></li>
			<li><a href='/gifts'>Хочу подарить</a></li>
			<li>
				<hr style='width: 90%; background-color: white'>
				<a href='/profile'>
					<Profile shouldShowText={showText}
									 photoSrc={cat}
									 userName='Pizdabol ivanovich'
									 style='width: {0.8*width}px;'
					/>
				</a>
			</li>
		</menu>
		<input 
			type='checkbox' 
			id='menu-checkbox-1' 
			class='menu-checkbox' 
			on:change={adjustElementsAccordingToWindowSize}
			bind:this={checkBox}
		/>
		<label for='menu-checkbox-1' class='menu-btn'>&#9776;</label>
	</div>
</nav>