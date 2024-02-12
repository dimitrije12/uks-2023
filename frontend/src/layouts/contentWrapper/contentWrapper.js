const ContentWrapper = ({ children }) => {
  return (
    <div className="flex flex-col items-stretch min-h-screen w-screen">
      {children}
    </div>
  );
};

export default ContentWrapper;
