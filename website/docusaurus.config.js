// @ts-check
// Note: type annotations allow type checking and IDEs autocompletion

const lightCodeTheme = require('prism-react-renderer/themes/github');
const darkCodeTheme = require('prism-react-renderer/themes/dracula');

/** @type {import('@docusaurus/types').Config} */
const config = {
  title: 'NUKE',
  url: 'https://nuke.build',
  baseUrl: '/',
  onBrokenLinks: 'throw',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/favicon.ico',
  organizationName: 'nuke-build', // Usually your GitHub org/user name.
  projectName: 'nuke', // Usually your repo name.
  trailingSlash: true,

  stylesheets: [
    {
      rel: "preload",
      as: "image",
      href: "/img/background.webp",
    },
  ],
  scripts: [
    {
      src: 'https://fa.nuke.build/script.js',
      defer: true,
      'data-site': 'CNJKKHNI',
      'data-spa': 'auto',
    },
  ],
  clientModules: [
    require.resolve('./analytics.js'),
  ],

  presets: [
    [
      'classic',
      /** @type {import('@docusaurus/preset-classic').Options} */
      ({
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          editUrl: 'https://github.com/nuke-build/nuke/edit/develop/website/',
          showLastUpdateAuthor: true,
          showLastUpdateTime: true,
          remarkPlugins: [require('mdx-mermaid')],
          breadcrumbs: false,
        },
        blog: {
          blogSidebarTitle: 'Recent posts',
          showReadingTime: true,
          blogTitle: 'Blog',
          blogDescription: 'The latest posts about NUKE',
          editUrl: 'https://github.com/nuke-build/nuke/edit/develop/website/',
          // feedOptions: {
          //   type: 'all',
          //   copyright: `Copyright © ${new Date().getFullYear()} Facebook, Inc.`,
          // },
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      }),
    ],
  ],
  plugins: [
    [
      '@docusaurus/plugin-content-blog',
      {
        id: 'articles',
        routeBasePath: 'articles',
        path: './articles',
        blogSidebarTitle: 'Recent articles',
        blogTitle: 'Articles',
        blogDescription: 'The latest articles about general build automation',
        showReadingTime: true,
        editUrl: 'https://github.com/nuke-build/nuke/edit/develop/website/',
      },
    ],
    [
      'pwa',
      {
        // https://web.dev/pwa-checklist/
        // https://developer.mozilla.org/en-US/docs/Web/Manifest
        // https://medium.com/@applification/progressive-web-app-splash-screens-80340b45d210
        offlineModeActivationStrategies: [
          'appInstalled',
          'standalone',
          'queryString',
        ],
        pwaHead: [
          {
            tagName: 'link',
            rel: 'manifest',
            href: 'manifest.json',
          },
          {
            tagName: 'link',
            rel: 'icon',
            href: 'img/icons/maskable_icon_x512.png',
          },
          {
            tagName: 'meta',
            name: 'theme-color',
            content: '#000',
          },
          {
            tagName: 'meta',
            name: 'apple-mobile-web-app-capable',
            content: 'yes',
          },
          {
            tagName: 'meta',
            name: 'apple-mobile-web-app-status-bar-style',
            content: '#000',
          },
          {
            tagName: 'link',
            rel: 'apple-touch-icon',
            href: 'img/icons/maskable_icon_x512.png',
          },
          {
            tagName: 'link',
            rel: 'mask-icon',
            href: 'img/icons/maskable_icon_x512.png',
            color: '#000',
          },
          {
            tagName: 'meta',
            name: 'msapplication-TileImage',
            content: 'img/icons/maskable_icon_x512.png',
          },
          {
            tagName: 'meta',
            name: 'msapplication-TileColor',
            content: '#000',
          },
          {
            tagName: "link",
            rel: "apple-touch-startup-image",
            href: "images/splash/launch-640x1136.png",
            media: "(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2) and (orientation: portrait)"
          },
          {
            tagName: "link",
            rel: "apple-touch-startup-image",
            href: "img/splash/launch-750x1294.png",
            media: "(device-width: 375px) and (device-height: 667px) and (-webkit-device-pixel-ratio: 2) and (orientation: portrait)"
          },
          {
            tagName: "link",
            rel: "apple-touch-startup-image",
            href: "img/splash/launch-1242x2148.png",
            media: "(device-width: 414px) and (device-height: 736px) and (-webkit-device-pixel-ratio: 3) and (orientation: portrait)"
          },
          {
            tagName: "link",
            rel: "apple-touch-startup-image",
            href: "img/splash/launch-1125x2436.png",
            media: "(device-width: 375px) and (device-height: 812px) and (-webkit-device-pixel-ratio: 3) and (orientation: portrait)"
          },
          {
            tagName: "link",
            rel: "apple-touch-startup-image",
            href: "img/splash/launch-1536x2048.png",
            media: "(min-device-width: 768px) and (max-device-width: 1024px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait)"
          },
          {
            tagName: "link",
            rel: "apple-touch-startup-image",
            href: "img/splash/launch-1668x2224.png",
            media: "(min-device-width: 834px) and (max-device-width: 834px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait)"
          },
          {
            tagName: "link",
            rel: "apple-touch-startup-image",
            href: "img/splash/launch-2048x2732.png",
            media: "(min-device-width: 1024px) and (max-device-width: 1024px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait)"
          },
        ],
      },
    ],
    [
      '@docusaurus/plugin-client-redirects',
      {
        redirects: [
          { from: '/docs/getting-started/philosophy.html', to: '/docs/introduction' },
          { from: '/docs/getting-started/telemetry.html', to: '/docs/getting-started/telemetry' },
          { from: '/docs/getting-started/resources.html', to: '/resources' },
          { from: '/docs/getting-started/faq.html', to: '/faq' },
          { from: '/docs/running-builds/fundamentals.html', to: '/docs/getting-started/execution' },
          { from: '/docs/running-builds/global-tool.html', to: '/docs/getting-started/execution' },
          { from: '/docs/running-builds/from-ides.html', to: '/docs/ide/rider' },
          { from: '/docs/authoring-builds/fundamentals.html', to: '/docs/fundamentals/builds' },
          { from: '/docs/authoring-builds/logging-and-assertions.html', to: '/docs/fundamentals/logging' },
          { from: '/docs/authoring-builds/predefined-parameters.html', to: '/docs/fundamentals/builds' },
          { from: '/docs/authoring-builds/parameter-declaration.html', to: '/docs/fundamentals/parameters' },
          { from: '/docs/authoring-builds/ci-integration.html', to: '/docs/cicd/github-actions' },
          { from: '/docs/authoring-builds/system-paths.html', to: '/docs/common/paths' },
          { from: '/docs/authoring-builds/solutions-and-projects.html', to: '/docs/common/solution-project-model' },
          { from: '/docs/authoring-builds/cli-tools.html', to: '/docs/common/cli-tools' },
          { from: '/docs/authoring-builds/events.html', to: '/docs/fundamentals/builds' },
          { from: '/docs/sharing-builds/fundamentals.html', to: '/docs/sharing/global-builds' },
          { from: '/docs/sharing-builds/external-files.html', to: '/docs/sharing/global-builds' },
          { from: '/docs/sharing-builds/global-tools.html', to: '/docs/sharing/global-builds' },
          { from: '/docs/sharing-builds/build-components.html', to: '/docs/sharing/build-components' },

          { from: '/telemetry', to: '/docs/getting-started/telemetry' },
          { from: '/rider', to: '/docs/ide/rider' },
          { from: '/resharper', to: '/docs/ide/resharper' },
          { from: '/visualstudio', to: '/docs/ide/visual-studio' },
          { from: '/vscode', to: '/docs/ide/vscode' },
        ],
      },
    ],
  ],

  themeConfig:
    /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
    ({
      image: 'img/social.png',

      // https://github.com/algolia/docsearch-configs/blob/master/configs/docusaurus-2.json
      algolia: {
        // The application ID provided by Algolia
        appId: '4UUQOSTPKA',

        // Public API key: it is safe to commit it
        apiKey: '7629587e946b9f8a872b8ed77ed0f3ae',

        indexName: 'nuke',

        // Optional: see doc section below
        contextualSearch: true,

        // Optional: Specify domains where the navigation should occur through window.location instead on history.push. Useful when our Algolia config crawls multiple documentation sites and we want to navigate with window.location.href to them.
        externalUrlRegex: 'external\\.com|domain\\.com',

        // Optional: Algolia search parameters
        searchParameters: {},

        //... other Algolia params
      },
      announcementBar: {
        id: 'announcementBar-1', // Increment on change
        content: `⭐️ If you like NUKE, give it a star on <a href="https://github.com/nuke-build/nuke" target="_blank" rel="noopener noreferrer">GitHub</a> and follow us on <a href="https://twitter.com/nukebuildnet" target="_blank" rel="noopener noreferrer">Twitter</a> ⭐️`,
      },
      colorMode: {
        defaultMode: 'dark',
        // respectPrefersColorScheme: true,
      },
      navbar: {
        title: '',
        style: 'dark',
        logo: {
          alt: 'NUKE',
          src: 'img/nuke.svg',
        },
        items: [
          {
            to: '/blog',
            label: 'Blog',
            position: 'left'
          },
          {
            type: 'doc',
            docId: 'introduction',
            position: 'left',
            label: 'Documentation',
          },
          {
            to: 'resources',
            position: 'left',
            label: 'Resources',
          },
          {
            to: '/articles',
            label: 'Articles',
            position: 'left'
          },
          {
            to: 'faq',
            position: 'left',
            label: 'FAQ',
          },
          {
            href: 'https://github.com/sponsors/matkoch',
            position: 'right',
            className: 'header-heart-link',
            'aria-label': 'Support NUKE',
          },
          {
            href: 'https://github.com/nuke-build/nuke',
            position: 'right',
            className: 'header-github-link',
            'aria-label': 'GitHub Repository',
          },
          {
            href: 'https://communityinviter.com/apps/nukebuildnet/nuke',
            position: 'right',
            className: 'header-slack-link',
            'aria-label': 'Slack Workspace',
          },
          {
            href: 'https://discord.gg/6AbK88ysuw',
            position: 'right',
            className: 'header-discord-link',
            'aria-label': 'Discord Server',
          },
          {
            href: 'https://twitter.com/nukebuildnet',
            position: 'right',
            className: 'header-twitter-link',
            'aria-label': 'Twitter Profile',
          },
        ],
      },
      docs: {
        sidebar: {
          hideable: true,
          autoCollapseCategories: false,
        }
      },
      footer: {
        style: 'dark',
      },
      prism: {
        theme: lightCodeTheme,
        darkTheme: darkCodeTheme,
        additionalLanguages: ['powershell', 'csharp', 'yaml'],
      },
    }),
};

module.exports = config;
