<script lang='ts'>
	export let photoSrc = '';
	export let userName = 'User not specified';
	export let shouldShowText = true;
</script>

<div
	class="profile { shouldShowText ?  'left-content' : 'center-content'}"
	style={$$props.style}
>
	{#if shouldShowText}
		<p class='profile-name'>{ userName }</p>
	{/if}
	<div class='profile-photo'>
		<img src={ photoSrc } alt='photo'>
	</div>
</div>

<style>
    .profile {
				width: 100%;
        display: flex;
        align-items: center;
        gap: 15px;
    }

    .center-content {
        justify-content: center;
    }

    .left-content {
        justify-content: flex-end;
    }

    .profile-photo {
        display: block;
        min-height: 40px;
        min-width: 40px;
				max-width: 40px;
				max-height: 40px;
        border-radius: 50%;
        background: silver;
        overflow: hidden;
    }

    .profile-photo > img {
        max-width: 100%;
        max-height: 100%;
    }
		
		.profile-name {
        display: inline-block; /* so height and width actually take affect */
        height: 1em; /* so overflow hidden works and keeps text on one row */
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
		}
</style>