<script lang='ts'>
    export let targetUrl: string = '#';
    export let label: string = '#';
</script>

<li class='menu-item' on:click>
    <a href='{targetUrl}'>
        <slot>{label}</slot>
    </a>
</li>


<style lang='less'>
  @import "../themes/default";

  .menu-item {
    list-style-type: none;
    justify-content: inherit;
  }

  a {
    display: flex;
    justify-content: center;
    align-items: center;
    
    white-space: nowrap;
    padding: 0.2em;
    border-radius: 10px;
  }

  a:hover {
    color: @accentColor;
    scale: 1.1;
    transition: all 0.1s;
  }
</style>