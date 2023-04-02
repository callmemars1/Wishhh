<script>
	import Header from '$lib/components/Header.svelte';
	import Footer from '../../lib/components/Footer.svelte';
</script>

<svelte:head>
	<link rel='stylesheet' href='styles.css'>
</svelte:head>

<div class='keep-items-middle'>
	<div class='sticky'>
		<Header />
	</div>
	
	<main>
		<slot />
	</main>
	
	<Footer/>
</div>

<style>
    .keep-items-middle {
        display: flex;
				flex-direction: column;
        min-height: 100vh;
        flex-basis: 100%;
        flex-wrap: wrap;
				gap: 20px;
				
				align-items: center;
        padding: 0 20%;
    }
		
		.keep-items-middle > * {
        max-width: 900px;
        margin-left: auto;
        margin-right: auto;
		}
		
		main {
				flex: 1;
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
