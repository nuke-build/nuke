/**
 * Copyright (c) Facebook, Inc. and its affiliates.
 *
 * This source code is licensed under the MIT license found in the
 * LICENSE file in the root directory of this source tree.
 */
import React from 'react';
import clsx from 'clsx';
import Link from '@docusaurus/Link';
import {useThemeConfig} from '@docusaurus/theme-common';
import styles from './styles.module.css';

const BIG_SPONSORS = [
  {
    name: 'Octopus Deploy',
    color: '#0F80D9',
    image: '/img/sponsors/octopus-deploy.svg',
    href: 'https://octopus.com',
  },
]

const SMALL_SPONSORS = [
  {
    name: 'Raw Coding',
    color: '#1B0E1F',
    image: '/img/sponsors/raw-coding.png',
    href: 'https://www.youtube.com/c/RawCoding',
  },
  {
    name: 'DanglIT GmbH',
    color: '#05ACC1',
    image: '/img/sponsors/dangl-it.png',
    href: 'https://www.dangl-it.com/',
  },
  {
    name: 'MultiNet Interactive AB',
    color: '#FFFFFF',
    image: '/img/sponsors/multinet.png',
    href: 'https://www.multinet.com/',
  },
  {
    name: 'Virto Commerce',
    color: '#ffffff',
    image: '/img/sponsors/virto-commerce.png',
    href: 'https://virtocommerce.com',
  },
];

function shuffle(array) {
  let currentIndex = array.length,  randomIndex;

  // While there remain elements to shuffle...
  while (currentIndex != 1) {

    // Pick a remaining element...
    randomIndex = Math.floor(Math.random() * currentIndex);
    currentIndex--;

    // And swap it with the current element.
    [array[currentIndex], array[randomIndex]] = [
      array[randomIndex], array[currentIndex]];
  }

  return array;
}

function Sponsors() {
  return (
      <>
        <h2>Our Sponsors</h2>
        <div className={clsx(styles.sponsorContainer, "row")}>
          {BIG_SPONSORS.concat(shuffle(SMALL_SPONSORS).slice(0, 1)).map((item, key) => (
              <React.Fragment key={key}>
                <div className={clsx(styles.sponsor, "col")} style={{backgroundColor: item.color}}>
                  <Link to={item.href}>
                    <img src={item.image} alt={item.name} />
                  </Link>
                </div>
              </React.Fragment>
          ))}
        </div>
      </>
  );
}
function Footer() {
  const {footer} = useThemeConfig();

  return (
    <footer
      className={clsx('footer', 'footer--dark', styles.footer)}>
      <div className="container container-fluid">
        <div className={clsx(styles.footerStack, 'row')}>
          <div className="col col--5">
            <h2>NUKE</h2>
            <p className={styles.footerText}>
              The next-generation .NET build automation system.<br/>
              Developed and designed by <Link to="https://github.com/matkoch">Matthias&nbsp;Koch</Link> and <Link to="https://github.com/ulrichb">Ulrich&nbsp;Buchgraber</Link>.
            </p>
            <div className={clsx(styles.footerLinks)}>
              {/*<Link to="https://github.com/sponsors/matkoch" className="heart-link" />*/}
              <Link to="mailto:info@nuke.build?subject=Help%20with%20NUKE&body=Hi%20NUKE-Team%20%F0%9F%91%8B%0D%0A%0D%0AI'm%20reaching%20out%20to%20discuss%20...%0D%0A%0D%0AI'm%20ready%20to%20pay%20an%20hourly%20rate%20that%20we%20can%20agree%20on." className="email-link" aria-label="Email Contact" />
              <Link to="https://github.com/nuke-build/nuke" className="github-link" aria-label="GitHub Repository" />
              <Link to="https://communityinviter.com/apps/nukebuildnet/nuke" className="slack-link" aria-label="Slack Workspace" />
              <Link to="https://discord.gg/6AbK88ysuw" className="discord-link" aria-label="Discord Server" />
              <Link to="https://twitter.com/nukebuildnet" className="twitter-link" aria-label="Twitter Profile" />
            </div>
            <p className={clsx(styles.copyright)}>
              Copyright © {new Date().getFullYear()} Matthias Koch | <Link to='/legal'>Legal Disclosures</Link><br/>
              <Link to="https://www.iconfinder.com/iconsets/geometric-hearts-valentine-s-day">Geometric Hearts</Link> by <Link to="https://www.behance.net/katerinemelina">Katerine Melina</Link> is licensed under <Link to="https://www.iconfinder.com/iconsets/geometric-hearts-valentine-s-day">CC BY 3.0</Link><br/>
              <Link to="https://undraw.co">unDraw illustrations</Link> by <Link to="https://ninalimpi.com/">Katerina Limpitsouni</Link>
            </p>
          </div>
          <div className="col">
            <Sponsors />
          </div>
        </div>
      </div>
    </footer>
  );
}

export default React.memo(Footer);
