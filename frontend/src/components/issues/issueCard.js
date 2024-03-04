const IssueCard = ({ username, title, openedDate, labels, description }) => {
  return (
    <div
      className="rounded-lg border bg-card text-card-foreground shadow-sm"
      data-v0-t="card"
    >
      <div className="flex-col space-y-1.5 p-6 flex items-start gap-4 pb-0">
        <div className="flex items-center space-x-2">
          <span className="relative flex shrink-0 overflow-hidden rounded-full w-8 h-8">
            <div>{username}</div>
          </span>
          <div className="text-sm">
            {/* Issue title */}
            <a className="font-medium" href="#" rel="ugc">
              {title}
            </a>
            {/* Issue details */}
            <div className="flex items-center space-x-2 text-xs text-gray-500 dark:text-gray-400">
              {/* Opened date icon */}
              <svg
                xmlns="http://www.w3.org/2000/svg"
                width="24"
                height="24"
                viewBox="0 0 24 24"
                fill="none"
                stroke="currentColor"
                strokeWidth="2"
                strokeLinecap="round"
                strokeLinejoin="round"
                className="h-3 w-3 -translate-y-0.5 mr-1.5"
              >
                <rect width="18" height="18" x="3" y="4" rx="2" ry="2"></rect>
                <line x1="16" x2="16" y1="2" y2="6"></line>
                <line x1="8" x2="8" y1="2" y2="6"></line>
                <line x1="3" x2="21" y1="10" y2="10"></line>
              </svg>
              Opened {openedDate} by
              {/* Username link */}
              <a className="underline" href="#" rel="ugc">
                {username}
              </a>
            </div>
          </div>
        </div>
        <div className="flex items-center space-x-2">
          {/* Labels */}
          {labels.map((label) => (
            <div
              key={label}
              className="inline-flex items-center rounded-full whitespace-nowrap border px-2.5 py-0.5 w-fit text-xs font-semibold transition-colors focus:outline-none focus:ring-2 focus:ring-ring focus:ring-offset-2 text-foreground"
              color="gray"
            >
              {label}
            </div>
          ))}
        </div>
      </div>
      {/* Issue description */}
      <div className="p-6 text-sm">{description}</div>
    </div>
  );
};

export default IssueCard;
