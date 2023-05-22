<script lang="ts">
    import PreloaderField from '$lib/components/PreloaderField.svelte';
    
    export let name: string = ""
    export let imageUri: string = ""
    export let loading: boolean = false
</script>

<div class='profile'>
    {#if loading}
        <PreloaderField width="120px" height="25px"/>
        <PreloaderField width="40px" height="40px" radius="50%"/>
    {:else }
        <span>{name}</span>
        <div class='profile-photo'>
            <img src={imageUri} alt='photo'>
        </div>
    {/if}
</div>

<style lang='less'>
  @import '../themes/default';

  .profile {
    display: inline-flex;
    flex-wrap: nowrap;
    justify-content: center;
    align-items: center;
    gap: 15px;
  }

  .profile span {
    max-width: 16ch;
    text-overflow: ellipsis;
    overflow: hidden;
  }

  .profile-photo {
    border-radius: 50%;
    border: 2px solid @accentColor;
    overflow: hidden;
    width: 40px;
    height: 40px;
    background: silver;
  }

  .profile-photo img {
    width: 100%;
    height: 100%;
  }

</style>