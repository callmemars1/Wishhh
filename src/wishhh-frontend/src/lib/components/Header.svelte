<script>
    import MenuItem from './MenuItem.svelte';
    import Menu from './Menu.svelte';
    import Logo from './Logo.svelte';
    import NavPanel from './NavPanel.svelte';
    import TextButton from './controls/TextButton.svelte';
    import Profile from './Profile.svelte';

    let panelOpen = false;
    const closePanel = () => panelOpen = false;
</script>

<div class='header'>

    <div class='links'>
        <div class='logo'>
            <a href='/'>
                <Logo/>
            </a>
        </div>

        <nav class='only-desktop'>
            <Menu>
                <MenuItem label='желания' targetUrl='/wishlists'/>
                <MenuItem label='подарки' targetUrl='/gifts'/>
                <MenuItem targetUrl='/profile'>
                    <Profile />
                </MenuItem>
            </Menu>
        </nav>

        <div class='only-mobile'>
            <TextButton text='&#9776;' on:click={() => panelOpen = true}/>
        </div>
    </div>

</div>

<div class='nav-panel only-mobile'>
    <NavPanel bind:open={panelOpen}>
        <MenuItem label='wishes' targetUrl='/wishlists' on:click={closePanel}/>
        <MenuItem label='gifts' targetUrl='/gifts' on:click={closePanel}/>
        <MenuItem targetUrl='/profile' on:click={closePanel}>
            <Profile/>
        </MenuItem>
    </NavPanel>
</div>

<style lang='less'>
  @import "../themes/default";

  .header {
    font: @headerFont;
    color: @headerForegroundColor;
    background: @mainBackground;
    border-radius: 5px;

    display: flex;
    min-height: @header-size;
    max-height: @header-size;

    justify-content: space-around;
    align-items: center;
    z-index: 1000;
  }

  .links {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    max-width: @view-max-width;
    padding: 0 50px;
    gap: 10%;
  }

  .logo:hover {
    scale: 1.05;
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