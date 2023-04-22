<script>
	import Header from '../../lib/components/Header.svelte';
	import Footer from '../../lib/components/Footer.svelte';
</script>

<div class='wrapper'>
	<div class='main-content'>
		<div class='sticky'>
			<Header />
		</div>
		<slot />
	</div>
	<footer>
		<Footer />
	</footer>
</div>

<style>
    .wrapper {
        display: flex;
        flex-direction: column;
        gap: 40px;

        align-items: center;
        width: 100%;
    }
		
		.main-content {
				width: 100%;
		}

    .sticky {
        position: sticky;
        top: 0;
        width: 100%;
    }

    footer {
        width: 80%;
        margin-top: auto;
    }
</style>
	