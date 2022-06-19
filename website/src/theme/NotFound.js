import React from 'react';
import Layout from '@theme/Layout';
import Translate, {translate} from '@docusaurus/Translate';
import {PageMetadata} from '@docusaurus/theme-common';
import Link from "@docusaurus/core/lib/client/exports/Link";
import useBaseUrl from "@docusaurus/core/lib/client/exports/useBaseUrl";
import ExecutionEnvironment from '@docusaurus/ExecutionEnvironment';

export default function NotFound() {

  if (ExecutionEnvironment.canUseDOM) {
    let path = window.location.pathname.toLowerCase();

    let map = {
      // CI/CD
      'AppVeyor': '/docs/cicd/appveyor',
      'AzurePipelines': '/docs/cicd/azure-pipelines',
      'Bitbucket': '/docs/cicd/bitbucket',
      'GitHub Actions': '/docs/cicd/github-actions',
      'GitLab': '/docs/cicd/gitlab',
      'Jenkins': '/docs/cicd/jenkins',
      'SpaceAutomation': '/docs/cicd/space-automation',
      'TeamCity': '/docs/cicd/teamcity',
      // CLI Tools
      'AzureSignTool': '/docs/common/cli-tools',
      'BenchmarkDotNet': '/docs/common/cli-tools',
      'Boots': '/docs/common/cli-tools',
      'Chocolatey': '/docs/common/cli-tools',
      'CloudFoundry': '/docs/common/cli-tools',
      'Codecov': '/docs/common/cli-tools',
      'CodeMetrics': '/docs/common/cli-tools',
      'CorFlags': '/docs/common/cli-tools',
      'CoverallsNet': '/docs/common/cli-tools',
      'Coverlet': '/docs/common/cli-tools',
      'DocFX': '/docs/common/cli-tools',
      'Docker': '/docs/common/cli-tools',
      'DotCover': '/docs/common/cli-tools',
      'DotNet': '/docs/common/cli-tools',
      'EntityFramework': '/docs/common/cli-tools',
      'Fixie': '/docs/common/cli-tools',
      'GitLink': '/docs/common/cli-tools',
      'GitReleaseManager': '/docs/common/cli-tools',
      'GitVersion': '/docs/common/cli-tools',
      'Helm': '/docs/common/cli-tools',
      'ILRepack': '/docs/common/cli-tools',
      'InnoSetup': '/docs/common/cli-tools',
      'Kubernetes': '/docs/common/cli-tools',
      'MauiCheck': '/docs/common/cli-tools',
      'MinVer': '/docs/common/cli-tools',
      'MSBuild': '/docs/common/cli-tools',
      'MSpec': '/docs/common/cli-tools',
      'NerdbankGitVersioning': '/docs/common/cli-tools',
      'Netlify': '/docs/common/cli-tools',
      'Npm': '/docs/common/cli-tools',
      'NSwag': '/docs/common/cli-tools',
      'NuGet': '/docs/common/cli-tools',
      'NUnit': '/docs/common/cli-tools',
      'Octopus': '/docs/common/cli-tools',
      'OctoVersion': '/docs/common/cli-tools',
      'OpenCover': '/docs/common/cli-tools',
      'Paket': '/docs/common/cli-tools',
      'PowerShell': '/docs/common/cli-tools',
      'Pulumi': '/docs/common/cli-tools',
      'ReportGenerator': '/docs/common/cli-tools',
      'ReSharper': '/docs/common/cli-tools',
      'SignClient': '/docs/common/cli-tools',
      'SignTool': '/docs/common/cli-tools',
      'SonarScanner': '/docs/common/cli-tools',
      'SpecFlow': '/docs/common/cli-tools',
      'Squirrel': '/docs/common/cli-tools',
      'TestCloud': '/docs/common/cli-tools',
      'Unity': '/docs/common/cli-tools',
      'VSTest': '/docs/common/cli-tools',
      'VSWhere': '/docs/common/cli-tools',
      'WebConfigTransformRunner': '/docs/common/cli-tools',
      'Xunit': '/docs/common/cli-tools',
    }

    for (let key in map) {
      if (path.includes(key.toLowerCase())) {
        let destination = map[key];
        window.location.href = destination + (destination.endsWith('cli-tools') ? `?tool=${key}` : undefined);
      }
    }
  }

  return (
    <>
      <PageMetadata
        title={translate({
          id: 'theme.NotFound.title',
          message: 'Page Not Found',
        })}
      />
      <Layout>
        <main className="container margin-vert--xl">
          <div className="row">
            <div className="col col--6 col--offset-3">
              <h1 className="hero__title">
                <Translate
                  id="theme.NotFound.title"
                  description="The title of the 404 page">
                  (╯°□°）╯︵ 404
                </Translate>
              </h1>
              <p style={{fontSize:"large"}}>
                Seems your search engine has not yet indexed our shiny new website.
              </p>
              <Link className="button button--lg button--secondary button--outline"
                    to="https://github.com/nuke-build/nuke/issues/941"
              style={{marginRight:"20px"}}>
                <Translate>Report Broken Link</Translate>
              </Link>
              <Link className="button button--lg button--secondary button--outline" to={useBaseUrl('/search')}>
                <Translate>Use Local Search</Translate>
              </Link>
            </div>
          </div>
        </main>
      </Layout>
    </>
  );
}
