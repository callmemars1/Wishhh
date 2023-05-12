<script>
    import photo from '../assets/avatar.jpeg';
</script>

<div class='profile'>
    <span>Sergey Martynov</span>
    <div class='profile-photo'>
        <img src={photo} alt=''>
    </div>
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