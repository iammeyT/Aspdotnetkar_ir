/* ===========================================================================
   Aspdotnetkar — اسکریپت مشترک
   =========================================================================== */
document.addEventListener('DOMContentLoaded', function () {

  /* -------------------------------------------------------------------
     ۱) تب «آخرین مطالب / پربازدیدترین مطالب» در صفحه‌ی اصلی
     ------------------------------------------------------------------- */
  var tabButtons = document.querySelectorAll('[data-blog-tab]');
  if (tabButtons.length) {
    tabButtons.forEach(function (btn) {
      btn.addEventListener('click', function () {
        var target = btn.getAttribute('data-blog-tab');

        tabButtons.forEach(function (b) { b.classList.remove('active'); });
        btn.classList.add('active');

        document.querySelectorAll('[data-blog-panel]').forEach(function (panel) {
          var isMatch = panel.getAttribute('data-blog-panel') === target;
          panel.classList.toggle('d-none', !isMatch);
        });
      });
    });
  }

  /* -------------------------------------------------------------------
     ۲) نمایش / مخفی کردن رمز عبور در فرم‌های ورود و ثبت‌نام
     ------------------------------------------------------------------- */
  document.querySelectorAll('.pass-toggle').forEach(function (icon) {
    icon.addEventListener('click', function () {
      var input = document.getElementById(icon.getAttribute('data-target'));
      if (!input) return;
      var showing = input.type === 'text';
      input.type = showing ? 'password' : 'text';
      icon.classList.toggle('bi-eye', showing);
      icon.classList.toggle('bi-eye-slash', !showing);
    });
  });

  /* -------------------------------------------------------------------
     ۳) فرم‌های نمایشی (ورود، ثبت‌نام، نظر، جست‌وجو)
        چون این پروژه فقط فرانت‌اند است، به‌جای ارسال واقعی، یک پیام
        وضعیت نمایش داده می‌شود.
     ------------------------------------------------------------------- */
  document.querySelectorAll('.js-demo-form').forEach(function (form) {
    form.addEventListener('submit', function (e) {
      e.preventDefault();
      var msgBox = form.querySelector('.form-status-msg');
      if (msgBox) {
        msgBox.classList.remove('d-none');
        msgBox.scrollIntoView({ block: 'nearest' });
      }
    });
  });

  /* -------------------------------------------------------------------
     ۴) بستن خودکار منوی موبایل بعد از کلیک روی یک لینک
     ------------------------------------------------------------------- */
  var navCollapse = document.getElementById('adkNav');
  if (navCollapse) {
    navCollapse.querySelectorAll('.nav-link').forEach(function (link) {
      link.addEventListener('click', function () {
        if (navCollapse.classList.contains('show') && window.bootstrap) {
          var instance = window.bootstrap.Collapse.getInstance(navCollapse);
          if (instance) instance.hide();
        }
      });
    });
  }

});
