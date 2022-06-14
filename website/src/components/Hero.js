import React from 'react';
import styles from './Hero.module.css';
import Translate, {translate} from "@docusaurus/core/lib/client/exports/Translate";
import useBaseUrl from "@docusaurus/core/lib/client/exports/useBaseUrl";
import Link from "@docusaurus/core/lib/client/exports/Link";

export default function Hero() {
    return (
        <div className={styles.hero} style={{backgroundImage: "url('/img/background.webp')"}}>
            <div className={styles.heroInner}>
                <h1 className={styles.heroProjectTagline}>
                    <img
                        alt={translate({message: 'NUKE'})}
                        className={styles.heroLogo}
                        src={useBaseUrl('/img/logo.svg')}
                        width="200"
                        height="200"
                    />
                    <span
                        className={styles.heroTitleTextHtml}
                        // eslint-disable-next-line react/no-danger
                        dangerouslySetInnerHTML={{
                            __html: translate({
                                id: 'homepage.hero.title',
                                message: 'Smart <b>automation</b> for DevOps <b>teams</b> and CI/CD <b>pipelines</b>',
                                description: 'Home page hero title, can contain simple html tags',
                            }),
                        }}
                    />
                </h1>
                <div className={styles.indexCtas}>
                    <Link className="button button--secondary button--outline" to={useBaseUrl('/docs/introduction')}>
                        <Translate>Get Started</Translate>
                    </Link>
                    <Link className="button button--secondary button--outline" to="https://youtu.be/SVD70QYvQ6I">
                        <Translate>Watch a Talk</Translate>
                    </Link>
                </div>
            </div>
        </div>
    );
}
