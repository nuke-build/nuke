import React from 'react';
import clsx from 'clsx'
import Translate from "@docusaurus/core/lib/client/exports/Translate";

import styles from './InstallButton.module.css'

export default function InstallButton({url, install, event}) {
  return (
    <div className={clsx(styles.installButton)}>
      <a href={url}
         target={install ? "install_frame" : "_blank"}
         rel="noopener noreferrer"
         className="button button--info button--outline button--install button--lg"
         onClick={event ? () => window.fathom.trackGoal(event, 0) : undefined}>
        {install ? <Translate>Install</Translate> : <Translate>Download</Translate>}
      </a>
      <iframe height="0" width="0" title="Install" name="install_frame"></iframe>
    </div>
  );
}
