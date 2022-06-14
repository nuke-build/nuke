import React from 'react';
import clsx from 'clsx'
import Link from "@docusaurus/core/lib/client/exports/Link";
import Translate from "@docusaurus/core/lib/client/exports/Translate";

import styles from './InstallButton.module.css'

export default function InstallButton({url}) {
    return (
        <div className={clsx(styles.installButton)}>
            <Link className="button button--info button--outline button--install button--lg"
                  to={url}>
                <Translate>Install</Translate>
            </Link>
        </div>
    );
}
