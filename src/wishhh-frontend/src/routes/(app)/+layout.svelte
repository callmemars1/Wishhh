<script lang="ts">
    import Header from '$lib/components/Header.svelte';
    import Footer from '$lib/components/Footer.svelte';
    import {updateUserDataStores} from '$lib/services/user';
    import {ensureAuthenticated} from '$lib/services/auth';
    import {
        displayName,
        imageUri
    } from '$lib/utils/stores'
    
    const processResponse = async () => {
        await ensureAuthenticated()
        await updateUserDataStores()
    }

    let promise: Promise<void> = processResponse()
</script>

<div class='wrapper'>
    <header>
        {#await promise}
            <Header loading/>
        {:then _}
            <Header displayName={$displayName} imageUri={$imageUri}/>
        {/await}
    </header>
    <main>
        <slot/>
    </main>
    <footer>
        <Footer/>
    </footer>
</div>

<style lang='less'>
  @import "../../../src/lib/themes/default";

  .wrapper {
    position: relative;
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 40px;
    background: @mainBackground;
    color: @foregroundColor;
    width: 100%;
    min-height: 100vh;
  }

  header {
    z-index: 1;
    top: 0;
    position: sticky;

    max-width: 1200px;
    width: 100%;
  }

  main {
    z-index: 0;
    width: 100%;
    max-width: @view-max-width;

    display: flex;
    flex: 1 1 auto;
    flex-direction: column;
    gap: 25px;

  }

  footer {
    width: 100%;

    height: @footer-size;
    max-width: @view-max-width;
  }
</style>
	