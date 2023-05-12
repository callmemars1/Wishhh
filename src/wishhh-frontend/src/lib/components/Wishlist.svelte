<script lang='ts'>
    import Icon from './Icon.svelte';
    import ImageStacked from './ImageStacked.svelte';

    export let name: string;
    export let isPrivate: boolean = false;

    let eyeName = isPrivate ? 'private-eye' : 'public-eye';
</script>

<div class='wishlist'>
    <div class='image'>
        <ImageStacked>
            <Icon name='wishlistImage' size='200px' slot='background'/>
            <div class='p-10 access' slot='top-left'>
                <Icon name={eyeName} size='40px'/>
            </div>
            <div class='letter' slot='center'>
                {name[0]}
            </div>
        </ImageStacked>
    </div>
    <span class='name'>{name}</span>
</div>

<style lang='less'>
  @import "../themes/default";

  .wishlist {
    display: flex;
    flex-direction: column;
    gap: 10px;
  }

  .image {
    overflow: hidden;
    border-radius: 15px;
  }

  .access {
    padding: 10px;
    color: fade(white, 70%);
    display: none;
  }

  .letter {
    font: @font;
    font-size: 150px;
    color: fade(white, 90%);
    width: 200px;
    height: 200px;
    display: flex;
    align-items: center;
    justify-content: center;
    padding-bottom: 25px;
  }

  .wishlist:hover {
    cursor: pointer;
  }

  .wishlist:hover .access {
    display: flex;
  }

  .name {
    max-width: 200px;
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    font-size: @size-s;
  }
</style>
