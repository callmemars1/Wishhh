<script>
    import ImageStacked from "$lib/components/ImageStacked.svelte"
    import photo from "$lib/assets/avatar.jpeg";
</script>

<svelte:head>
    <title>Profile</title>
</svelte:head>

<div class="wrapper">
    <aside>
        <ImageStacked width="100%" height="400px">
            <img src="{photo}" alt="" slot="background">
        </ImageStacked>
        <span>Sergey Martynov</span>
    </aside>

    <main>
        <div>
            <span>логин: </span>
            <span>callmemars111</span>
        </div>
        <div>
            <span>пароль: </span>
            <span>************</span>
        </div>

        <div>
            <span>Желаний: </span>
            <span>420</span>
        </div>

        <div>
            <span>Подарков: </span>
            <span>228</span>
        </div>
    </main>
</div>

<style lang="less">
  @import "../../../lib/themes/default";
  
  .wrapper {
    display: grid;
    grid-template-columns: 1fr 2fr;
    grid-column-gap: 40px;
    font: @font;
  }
  
  aside {
    display: flex;
    flex-direction: column;
    gap: 20px;
    align-items: flex-start;
  }
  
  main {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    gap: 20px;
    font-size: @size-s;
  }
  
  img {
    width: 100%;
    height: 100%;
    object-fit: cover;
  }
</style>
