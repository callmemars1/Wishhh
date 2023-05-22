<script>
    import Wishlist from '../../../lib/components/Wishlist.svelte';
    import Button from '../../../lib/components/controls/Button.svelte';
    import {requestWishlists} from '$lib/services/user';

    import {goto} from "$app/navigation";

    const processResponse = async () => {
        let data = await requestWishlists()
        if (data === undefined) {
            await goto('/error?status=404')
        }

        return data
    }

    let promise = processResponse()
</script>

<svelte:head>
    <title>Желания</title>
</svelte:head>

<div class='adm-panel'>
    <span>Списки желаний</span>
    <Button>создать</Button>
</div>

<div class='wishlist-grid'>
    {#await promise}
        <Wishlist loading/>
        <Wishlist loading/>
        <Wishlist loading/>
        <Wishlist loading/>
        <Wishlist loading/>
    {:then wishlists}
        {#if wishlists.length === 0}
            <span>Желаний пока нет :(</span>
        {:else }
            {#each wishlists as wishlist}
                <Wishlist isPrivate={wishlist.private} name={wishlist.name}/>
            {/each}
        {/if}
    {/await}
</div>

<style lang='less'>
  @import "../../../../src/lib/themes/default";

  * {
    font: @monoFont;
  }

  .adm-panel {
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    border: solid 2px @accentBackgroundColor;
    border-left: none;
    border-right: none;
    margin: 0 3%;
    padding: 0 2%;
    height: 60px;
  }

  .button {
    background: none;
    border: none;
    padding: 0.3em;
    border-radius: 5px;
  }

  .button:hover {
    background: @accentBackgroundColor;
    color: @accentForegroundColor;
    transition: all .1s;
    cursor: pointer;
  }

  .wishlist-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(250px, 1fr));
    grid-column-gap: 1rem;
    grid-row-gap: 50px;
    justify-items: center;
  }
</style>