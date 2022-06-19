import React from 'react';
import clsx from 'clsx';
import Layout from '@theme/Layout';
import Link from '@docusaurus/Link';
import useDocusaurusContext from '@docusaurus/useDocusaurusContext';
import CodeBlock from '@theme/CodeBlock';
import styles from './index.module.css';
import SmallFeatures from '../components/SmallFeatures';
import Testimonials from '../components/Testimonials';
import Hero from '../components/Hero';
import {BUILD_EXAMPLE, GET_STARTED, QUOTES, SMALL_FEATURES, YAML_EXAMPLE} from '../index-content'
import LargeFeature from "../components/LargeFeature";
import LiteYouTubeEmbed from 'react-lite-youtube-embed';
import 'react-lite-youtube-embed/dist/LiteYouTubeEmbed.css'
import AsciinemaPlayer from '../components/AsciinemaPlayer';
import 'asciinema-player/dist/bundle/asciinema-player.css';
import useBaseUrl from "@docusaurus/core/lib/client/exports/useBaseUrl";
import {PageMetadata} from "@docusaurus/theme-common";

// import Image from '@theme/IdealImage';
// https://freesvg.org/missile

export default function Home() {
    const {siteConfig} = useDocusaurusContext();
    return (
        <Layout title={`Smart automation for DevOps teams and CI/CD pipelines`}
                description="
                Make yourself at home with build automation that is bootstrapped with simple .NET console applications
                and build steps that are defined as regular C# properties. Integrate your builds in CI/CD environments
                within seconds and without the usual YAML struggle.">
            <PageMetadata>
                <link rel="preload" as="image" href="/img/background.webp" />
            </PageMetadata>
            <main>
                <Hero/>
                <LargeFeature
                    sectionStyle={clsx(styles.section, 'withIdeWindow')}
                    title="Unmatched Productivity"
                    first={
                        <>
                            <p>
                                Make yourself at home with build automation that is bootstrapped with simple <strong>
                                .NET console applications</strong> and build steps that are defined as regular C#
                                properties. No magic strings attached!
                            </p>
                            <p>
                                Enjoy <strong>first-class IDE integration</strong>. Features like code-completion,
                                navigation, refactorings, and debugging are supported out-of-the-box! For improved
                                development experience, you can install one of the support extensions.
                            </p>
                            <p>
                                <h3>Native and Extended Support for:</h3>
                                <div className={styles.toolLogo}>
                                  <Link to={useBaseUrl('/docs/ide/rider')}><img src="/img/tools/rider.svg" alt="JetBrains Rider"/></Link>
                                  <Link to={useBaseUrl('/docs/ide/resharper')}><img src="/img/tools/resharper.svg" alt="ReSharper"/></Link>
                                  <Link to={useBaseUrl('/docs/ide/visual-studio')}><img src="/img/tools/visual-studio.svg" alt="Visual Studio"/></Link>
                                  <Link to={useBaseUrl('/docs/ide/vscode')}><img src="/img/tools/vscode.svg" alt="Visual Studio Code"/></Link>
                                </div>
                            </p>
                        </>
                    }
                    second={
                        <CodeBlock language="csharp">{BUILD_EXAMPLE}</CodeBlock>
                    }/>
                <LargeFeature
                    sectionStyle={clsx(styles.section, styles.sectionAlt)}
                    reversed={true}
                    title="Get Started in Seconds"
                    first={
                        <>
                            <p>
                                NUKE comes with a .NET global tool that provides a comfortable way to <b>setup
                                and execute your build projects</b> right from your terminal.
                            </p>
                            <CodeBlock language="powershell">{GET_STARTED}</CodeBlock>
                            <p>
                                With additional configuration, you can get your global tool to complete targets
                                and parameters that are specific to your individual build.
                            </p>
                        </>
                    }
                    second={
                        <AsciinemaPlayer
                            src="/casts/getting-started.cast"
                            idleTimeLimit={3}
                            // autoplay={true}
                            poster="npt:4.947337"
                            preload={true}
                            // terminalFontFamily="'JetBrains Mono', Consolas, Menlo, 'Bitstream Vera Sans Mono', monospace"
                            loop={true}/>
                    }/>
                <SmallFeatures features={SMALL_FEATURES} sectionStyle={clsx(styles.section)}/>
                <LargeFeature
                    sectionStyle={clsx(styles.section, styles.sectionAlt, 'withIdeWindow')}
                    reversed
                    title="Ready for CI/CD"
                    first={
                        <>
                            <p>
                                Integrate your builds in CI/CD environments within seconds and without the usual YAML
                                struggle. Apply one of the <strong>built-in attributes to generate configuration
                                files</strong> based on your existing C# build definition. Every change is verified by
                                the compiler!
                            </p>
                            <p>
                                With multi-agent CI/CD services you can <strong>easily parallelize time-consuming build
                                steps</strong>, for example tests, to improve your build times! Other individual
                                features like caching, secret imports, and publishing artifacts come preconfigured.
                            </p>
                            <p>
                                <h3>Integration with:</h3>
                                <div className={styles.toolLogo}>
                                  <Link to={useBaseUrl('/docs/cicd/github-actions')}>
                                      <img src="/img/tools/github-light.svg#gh-dark-mode-only" alt="GitHub"/>
                                      <img src="/img/tools/github-dark.svg#gh-light-mode-only" alt="GitHub"/>
                                  </Link>
                                  <Link to={useBaseUrl('/docs/cicd/teamcity')}><img src="/img/tools/teamcity.svg" alt="TeamCity"/></Link>
                                  <Link to={useBaseUrl('/docs/cicd/azure-pipelines')}><img src="/img/tools/azure-pipelines.svg" alt="Azure Pipelines"/></Link>
                                  <Link to={useBaseUrl('/docs/cicd/gitlab')}><img src="/img/tools/gitlab.svg" alt="GitLab"/></Link>
                                  <Link to={useBaseUrl('/docs/cicd/bitbucket')}><img src="/img/tools/bitbucket.svg" alt="Bitbucket"/></Link>
                                  <Link to={useBaseUrl('/docs/cicd/space-automation')}><img src="/img/tools/space.svg" alt="JetBrains Space Automation"/></Link>
                                  <Link to={useBaseUrl('/docs/cicd/appveyor')}><img src="/img/tools/appveyor.svg" alt="AppVeyor"/></Link>
                                  <Link to={useBaseUrl('/docs/cicd/jenkins')}><img src="/img/tools/jenkins.svg" alt="Jenkins"/></Link>
                                </div>
                            </p>
                        </>
                    }
                    second={
                        <CodeBlock language="csharp">{YAML_EXAMPLE}</CodeBlock>
                    }/>
                <LargeFeature
                    sectionStyle={clsx(styles.section)}
                    reversed={false}
                    title="About our Community"
                    first={
                        <>
                            <p>
                                Our community is actively speaking about NUKE at conferences and meetups
                                around the world. Check out <Link to="https://youtu.be/kb3RQtU-Uzk"><strong>
                                Unleash your build with NUKE</strong></Link> presented by Todor Todorov at
                                the <Link to="https://devopsporto.com"><strong>DevOps Porto Meetup
                                </strong></Link>, which walks through some of the most distinguished features.
                            </p>
                            <p>
                                <h3>Community Sponsors:</h3>
                                <img src="https://avatars.githubusercontent.com/RLittlesII?s=42&v=4" alt="Rodney Littles II"/>
                                <img src="https://avatars.githubusercontent.com/onelioubov?s=42&v=4" alt="Olga Nelioubov"/>
                                <img src="https://avatars.githubusercontent.com/vova-lantsov-dev?s=42&v=4" alt="Vova Lantsov"/>
                                <img src="https://avatars.githubusercontent.com/valadas?s=42&v=4" alt="Daniel Valadas"/>
                                <img src="https://avatars.githubusercontent.com/T0shik?s=42&v=4" alt="Anton Wieslander"/>
                                <img src="https://avatars.githubusercontent.com/ChaseFlorell?s=42&v=4" alt="Chase Florell"/>
                                <img src="https://avatars.githubusercontent.com/BusinessActs?s=42&v=4" alt="business//acts"/>
                                <img src="https://avatars.githubusercontent.com/xsegno?s=42&v=4" alt="xsegno GmbH"/>
                                <img src="https://avatars.githubusercontent.com/chaquotay?s=42&v=4" alt="Stephan Müller"/>
                                <img src="https://avatars.githubusercontent.com/bitbonk?s=42&v=4" alt="Bitbonk"/>
                                <img src="https://avatars.githubusercontent.com/mattbrailsford?s=42&v=4" alt="Matt Brailsford"/>
                                <img src="https://avatars.githubusercontent.com/david-driscoll?s=42&v=4" alt="David Driscoll"/>
                                <img src="https://avatars.githubusercontent.com/Actipro?s=42&v=4" alt="Actipro Software"/>
                                <img src="https://avatars.githubusercontent.com/llaughlin?s=42&v=4" alt="Logan Laughlin"/>
                                <img src="https://avatars.githubusercontent.com/hardcoded2?s=42&v=4" alt="Alex Sink"/>
                                <img src="https://avatars.githubusercontent.com/MartinSGill?s=42&v=4" alt="Martin Gill"/>
                                <img src="https://avatars.githubusercontent.com/hfcook3?s=42&v=4" alt="Trey Cook"/>
                                <img src="https://avatars.githubusercontent.com/totollygeek?s=42&v=4" alt="Todor Todorov"/>
                                <img src="https://avatars.githubusercontent.com/stevenkuhn?s=42&v=4" alt="Steven Kuhn"/>
                                <img src="https://avatars.githubusercontent.com/rena0157?s=42&v=4" alt="Adam Renaud"/>
                                <img src="https://avatars.githubusercontent.com/vezel-dev?s=42&v=4" alt="Vezel"/>
                            </p>
                        </>
                    }
                    second={
                        <div className={clsx(styles.videoContainer)}>
                            <LiteYouTubeEmbed
                                id="kb3RQtU-Uzk"
                                params="autoplay=1&autohide=1&showinfo=0&rel=0"
                                title="Unleash your build with NUKE"
                                poster={"maxresdefault"}
                                webp={true}
                            />
                        </div>
                    }/>
                <Testimonials quotes={QUOTES} sectionStyle={clsx(styles.section, styles.sectionAlt)}/>
            </main>
        </Layout>
    );
}
