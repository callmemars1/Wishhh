<script>
	import Header from '$lib/components/Header.svelte';
	import Footer from '../../lib/components/Footer.svelte';
</script>

<svelte:head>
	<link rel='stylesheet' href='global.css'>
</svelte:head>

<div class='keep-items-middle'>
	<div class='header-stopper'>
		<div class='sticky'>
			<Header />
		</div>

		<main>
			<slot />
		</main>
	</div>

	<Footer />
</div>

<style>
    .keep-items-middle {
        display: flex;
        flex-direction: column;
        min-height: 100vh;
        flex-basis: 100%;
        flex-wrap: wrap;
        gap: 20px;
        background: linear-gradient(0deg, rgba(255, 255, 255, 1) 0%, var(--background-color) 1000%);

        align-items: center;
        padding: 0 20%;
    }

    .keep-items-middle > * {
        max-width: 900px;
        margin-left: auto;
        margin-right: auto;
    }

    .header-stopper {
				display: flex;
				flex-direction: column;
        gap: 20px;
        flex: 1;
        width: 100%;
    }

    main {
        width: 100%;
    }

    @media (max-width: 768px) {
        .keep-items-middle {
            padding: 0;
        }
    }

    .sticky {
        width: 100%;
        position: -webkit-sticky; /* for Safari */
        position: sticky;
        top: 0;
        align-self: flex-start;
    }
</style>
